using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace timerelay_server
{
    public class RelayController : ApiController
    {
        // GET api/timerelay
        [HttpGet]
        public string Get()
        {
            Console.WriteLine("Accepted Get");
            MainLogic.GetMainLogic().GetSettingsClick();
            return MainLogic.GetMainLogic().SaveSettingsJSON();
        }

        // POST api/timerelay
        [HttpPost]
        public HttpResponseMessage Post([FromBody]object text_json)
        {
            // start heavy work in separate thread
            new System.Threading.Tasks.Task(() =>
            {
                MainLogic.GetMainLogic().OpenSettingsJSON(text_json.ToString());
                MainLogic.GetMainLogic().SendSettingsClick();
            }).Start();

            Console.WriteLine("Accepted Post");
            Console.WriteLine(text_json);
            // Immeidately tell the client that his work is accepteed (code 202)
            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }

    }
}
