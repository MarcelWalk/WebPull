using LibGit2Sharp;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebPull
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(
                IPAddress.Parse(ConfigurationManager.AppSettings["LocalIp"]),
                int.Parse(ConfigurationManager.AppSettings["LocalPort"])
            );
            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                NetworkStream s = client.GetStream();
                StringBuilder sb = new StringBuilder();

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

                    byte[] hello = new byte[100];
                    hello = Encoding.Default.GetBytes("200");

                    s.Write(hello, 0, hello.Length);

                    if (Directory.Exists(ConfigurationManager.AppSettings["OutDir"]))
                    {
                        using (var repo = new LibGit2Sharp.Repository(ConfigurationManager.AppSettings["OutDir"]))
                        {
                            string logMessage = "";
                            var remote = repo.Network.Remotes["origin"];
                            var refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                            Commands.Fetch(repo, remote.Name, refSpecs, null, logMessage);
                        }
                    }
                    else
                    {
                        LibGit2Sharp.Repository.Clone(data.Repository.CloneUrl.ToString(), ConfigurationManager.AppSettings["OutDir"]);
                    }

                }
                else
                {
                    byte[] hello = new byte[100];
                    hello = Encoding.Default.GetBytes("404");

                    s.Write(hello, 0, hello.Length);
                }


                client.Close();
            }

        }
    }
}
