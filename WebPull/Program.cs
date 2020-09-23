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
                }catch{

                }
            }

        }
    }
}
