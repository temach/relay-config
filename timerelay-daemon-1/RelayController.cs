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
            Console.WriteLine("Accepted Post");
            Console.WriteLine(json.impulceMode);
            Console.WriteLine(json.impulceTimeOn);
            Console.WriteLine(json.impulceTimeOff);
            if (RelayAutoitNavigator.PushNewSettings(json))
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
        } 

    } 
}
