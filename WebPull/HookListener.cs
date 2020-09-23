using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebPull
{
    class HookListener
    {

        TcpListener tcpListener;

        public HookListener()
        {
            tcpListener = new TcpListener(
                          IPAddress.Parse(ConfigurationManager.AppSettings["LocalIp"]),
                          int.Parse(ConfigurationManager.AppSettings["LocalPort"])
                      );
        }

        public void Start()
        {
            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                NetworkStream s = client.GetStream();
                StringBuilder sb = new StringBuilder();

                Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] Hook recieved");

                while (s.DataAvailable)  //while the client is connected, we look for incoming messages
                {
                    byte[] msg = new byte[1024];     //the messages arrive as byte array
                    s.Read(msg, 0, msg.Length);
                    var dbg = Encoding.UTF8.GetString(msg).Trim('\0'); //the same networkstream reads the message sent by the client
                    sb.Append(dbg); //now , we write the message as string
                }

                var debug = sb.ToString();
                if (!string.IsNullOrEmpty(debug))
                {
                    GitData data = JsonConvert.DeserializeObject<GitData>(debug.Substring(debug.IndexOf("{")));

                    if (Directory.Exists(ConfigurationManager.AppSettings["OutDir"]))
                    {
                        Directory.Delete(ConfigurationManager.AppSettings["OutDir"], true);
                    }

                    LibGit2Sharp.Repository.Clone(data.Repository.CloneUrl.ToString(), ConfigurationManager.AppSettings["OutDir"]);

                    SendOkayResponse(s, "Ok");
                    Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] Repo published!");
                }
                else
                {
                    Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] Execution failed");
                }


                client.Close();
            }

            static void SendOkayResponse(NetworkStream s, string content)
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(s);
                writer.Write("HTTP/1.0 200 OK");
                writer.Write(Environment.NewLine);
                writer.Write("Content-Type: text/plain; charset=UTF-8");
                writer.Write(Environment.NewLine);
                writer.Write("Content-Length: " + content.Length);
                writer.Write(Environment.NewLine);
                writer.Write(Environment.NewLine);
                writer.Write(content);
                writer.Flush();
            }
        }
    }
}
