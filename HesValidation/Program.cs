using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace HesValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = { "G1B5-6449-15", "G5B2-3442-88" };

            List<string> risky = new List<string>();
            List<string> riskless = new List<string>();

            foreach (var item in data)
            {
                using (var client = new RestClient("https://api.saglikbakanligi.gov.tr/HES/dogrula"))
                {
                    var payload = new JObject();
                    payload.Add("hes", item);
                    var request = new RestRequest();
                    request.AddJsonBody(payload);
                    var result = client.PostAsync(request).Result;

                    if (result("status") == "risky")
                    {
                        risky.Add(item.hes);
                    }
                    else if(result("status") = "riskless")
                    {
                        riskless.Add(item.hes);
                    }
                }
            }
        }
    }
}
