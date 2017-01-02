using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace temerelay_client_1
{

    class Bootstrap
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.Run();
        }
    }

    class Program
    {
        public void Run()
        {
            // sleep one second, waiting for server to get ready
            Console.WriteLine("Client is waiting a bit...");
            System.Threading.Thread.Sleep(2000);

            string[] baseAddress = new string[] {
                "http://artem-windows:9000/"
            };

            foreach (var address in baseAddress)
            {
                Console.WriteLine(address);
                RelayClient cl = new RelayClient(address);

                // get old settings
                Console.WriteLine("Sending request out there =>");
                string prevSet = cl.GetSettings();

                Thread.Sleep(500);

                // make new settings
                string path_base = @"C:\Users\artem\Desktop\VS-2015-projects\timerelay-daemon-1\JsonToRelay";
                string input_path = @"\settings_sample_multi_timer.tmj";
                string putSet = File.ReadAllText(path_base + input_path);
                // string[] tmp = File.ReadAllLines(path_base + input_path);
                // string putSet = string.Join("\n", tmp.Select(x => x.Trim('\r', '\n', ' ')));
                Console.WriteLine("Sending request POST out there =>");
                if (cl.PutSettings(putSet))
                {
                    Console.WriteLine("Pushed settings");
                }
                else
                {
                    continue;
                }

                Thread.Sleep(500);

               //  // make new settings
               //  ChannelSettings ch1 = new ChannelSettings();
               //  ch1.programNumber = 1;
               //  ChannelSettings ch2 = new ChannelSettings();
               //  ch2.programNumber = 0;
               //  ProgramSettings pr1 = new ProgramSettings();
               //  pr1.impulceMode = true;
               //  pr1.impulceTimeOff = 4;
               //  pr1.impulceTimeOn = 2;
               //  ProgramSettings pr2 = new ProgramSettings();
               //  pr2.impulceMode = true;
               //  pr2.impulceTimeOff = 7;
               //  pr2.impulceTimeOn = 10;
               //  RelaySettings pushSet = new RelaySettings();
               //  pushSet.channels = new ChannelSettings[] { ch1, ch2 };
               //  pushSet.programs = new ProgramSettings[] { pr1, pr2 };

               //  // puch them
               //  Console.WriteLine("Sending request out there =>");
               //  if (cl.PutSettings(pushSet))
               //  {
               //      Console.WriteLine("Pushed settings");
               //  }

                // get new settings back to check
                Console.WriteLine("Sending request out there =>");
                string getSet = cl.GetSettings();
                if (getSet != null)
                {
                    Console.WriteLine("Retreived settings.");
                    // if they are equal to pushed settings
                }

            }
            Console.ReadLine();
        }
    }

}
