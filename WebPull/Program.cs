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
            while(true){
                try{
                                        HookListener hook = new HookListener();
                    hook.Start();
                    
                    System.Console.WriteLine("Executing post scripts...");
                    if(
                        File.Exists(ConfigurationManager.AppSettings["AdditionalCommands"] && 
                        !string.IsNullOrEmpty(File.Exists(ConfigurationManager.AppSettings["AdditionalCommands"])))
                    ){
                        foreach(var line in File.ReadAllLines(ConfigurationManager.AppSettings["AdditionalCommands"])){
                            System.Diagnostics.ProcessStartInfo procStartInfo;                
                            procStartInfo = new System.Diagnostics.ProcessStartInfo(line); 
                            procStartInfo.RedirectStandardOutput = true;
                            procStartInfo.RedirectStandardError = true;
                            procStartInfo.UseShellExecute = false;

                            procStartInfo.CreateNoWindow = true;

                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc.StartInfo = procStartInfo;
                            proc.Start();
                            // Get the output into a string
                            System.Console.WriteLine(proc.StandardOutput.ReadToEnd());
                        }

                    }


                }catch{

                }
            }

        }
    }
}
