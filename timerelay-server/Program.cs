using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using System.Net.Http;

namespace timerelay_server
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://+:9000/";
            Console.WriteLine("Getting device");
            // make a singleton to control the device
            MainLogic.GetMainLogic();
            Console.WriteLine("Server starting");
            // Start OWIN host
            WebApp.Start<Startup>(url: baseAddress);
            Console.WriteLine("Server ready.");
            Console.ReadLine();
        }
    }
}
