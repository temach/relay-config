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

            string baseAddress = "http://192.168.1.40:9000/";
            RelayClient cl = new RelayClient(baseAddress);

            // get old settings
            Console.WriteLine("Sending request out there =>");
            Settings prevSet = cl.GetSettings();

            // make new settings
            Settings pushSet = new Settings();
            pushSet.impulceMode = true;
            pushSet.impulceTimeOff = 4;
            pushSet.impulceTimeOn = 2;

            // puch them
            Console.WriteLine("Sending request out there =>");
            if (cl.PutSettings(pushSet))
            {
                Console.WriteLine("Pushed settings");
            }

            // get new settings back to check
            Console.WriteLine("Sending request out there =>");
            Settings getSet = cl.GetSettings();
            if (getSet != null)
            {
                Console.WriteLine("Retreived settings.");
                // if they are equal to pushed settings
                if (getSet.impulceMode == pushSet.impulceMode
                    && getSet.impulceTimeOff == pushSet.impulceTimeOff
                    && getSet.impulceTimeOn == pushSet.impulceTimeOn
                    // and not equal to old settings
                    && getSet.impulceMode != prevSet.impulceMode
                    && getSet.impulceTimeOff != prevSet.impulceTimeOff
                    && getSet.impulceTimeOn != prevSet.impulceTimeOn)
                {
                    Console.WriteLine("Test complete.");
                }
                else
                {
                    Console.WriteLine("ARH! Test FAILED!!");
                }
            }

            Console.ReadLine();
        }
    }

}
