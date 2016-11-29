using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace timerelay_daemon_1
{
    public class RelayController : ApiController
    {
        // GET api/timerelay
        public RelaySettings Get()
        {
            Console.WriteLine("Accepted Get");
            return RelayAutoitNavigator.CollectCurrentSettings();
        }

        // POST api/timerelay
        public HttpResponseMessage Post([FromBody]RelaySettings json)
        {
            // start heavy work in separate thread
            new System.Threading.Tasks.Task(() =>
            {
                Console.WriteLine("Accepted Post");
                Console.WriteLine(string.Join<ProgramSettings>(", ", json.programs));
                Console.WriteLine(string.Join<ChannelSettings>(", ", json.channels));
                RelayAutoitNavigator.PushNewSettings(json);
            }).Start();

            // Immeidately tell the client that his work is accepteed (code 202)
            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }

    }
}
