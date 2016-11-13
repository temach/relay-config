using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

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
            System.Threading.Thread.Sleep(3000);

            string[] baseAddress = new string[] {
                "http://192.168.1.39:9000/"
            };

            foreach (var address in baseAddress)
            {
                Console.WriteLine(address);
                RelayClient cl = new RelayClient(address);

                // get old settings
                Console.WriteLine("Sending request out there =>");
                RelaySettings prevSet = cl.GetSettings();

                // make new settings
                ChannelSettings ch1 = new ChannelSettings();
                ch1.programNumber = 1;
                ChannelSettings ch2 = new ChannelSettings();
                ch2.programNumber = 0;
                ProgramSettings pr1 = new ProgramSettings();
                pr1.impulceMode = true;
                pr1.impulceTimeOff = 4;
                pr1.impulceTimeOn = 2;
                ProgramSettings pr2 = new ProgramSettings();
                pr2.impulceMode = true;
                pr2.impulceTimeOff = 7;
                pr2.impulceTimeOn = 10;
                RelaySettings pushSet = new RelaySettings();
                pushSet.channels = new ChannelSettings[] { ch1, ch2 };
                pushSet.programs = new ProgramSettings[] { pr1, pr2 };

                // puch them
                Console.WriteLine("Sending request out there =>");
                if (cl.PutSettings(pushSet))
                {
                    Console.WriteLine("Pushed settings");
                }

                // get new settings back to check
                Console.WriteLine("Sending request out there =>");
                RelaySettings getSet = cl.GetSettings();
                if (getSet != null)
                {
                    Console.WriteLine("Retreived settings.");
                    // if they are equal to pushed settings
                    if (getSet.programs[0].impulceMode == pushSet.programs[0].impulceMode
                        && getSet.programs[0].impulceTimeOff == pushSet.programs[0].impulceTimeOff
                        && getSet.programs[0].impulceTimeOn == pushSet.programs[0].impulceTimeOn)
                    {
                        Console.WriteLine("Test complete.");
                    }
                    else
                    {
                        Console.WriteLine("ARH! Test FAILED!!");
                    }
                }

            }
            Console.ReadLine();
        }
    }

}
