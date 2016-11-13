using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace temerelay_client_1
{
    class RelayClient
    {
        string address;

        public RelayClient(string address)
        {
            this.address = address + "api/relay";
        }

        // Create HttpCient and make a request to api/values 
        public bool PutSettings(object obj)
        {
            HttpClient client = new HttpClient();
            var content = new StringContent( JsonConvert.SerializeObject(obj)
                , Encoding.UTF8, "application/json");
            try
            {
                 return client.PostAsync(address, content).Result.IsSuccessStatusCode;
            } catch (AggregateException e)
            {
                return false;
            }
        }

        // Create HttpCient and make a request to api/values 
        public RelaySettings GetSettings()
        {
            HttpClient client = new HttpClient();
            try
            {
                var resp = client.GetAsync(address).Result;
                if (resp.Content != null)
                {
                    string json = resp.Content.ReadAsStringAsync().Result;
                    if (json.Length > 10)
                    {
                        return JsonConvert.DeserializeObject<RelaySettings>(json);
                    }
                }
            }
            catch (AggregateException e)
            {
                return null;
            }
            return null; 
        }
    }
}
