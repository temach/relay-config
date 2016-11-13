using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using System.Net.Http;

namespace timerelay_daemon_1
{

 public class Program 
    { 
        static void Main() 
        { 
            string baseAddress = "http://+:9000/";
            Console.WriteLine("Server starting");
            // Start OWIN host 
            WebApp.Start<Startup>(url: baseAddress);
            Console.WriteLine("Server ready.");
            Console.ReadLine(); 
        } 
    } 
}
