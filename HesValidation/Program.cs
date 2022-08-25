using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HesValidation
{
    class HesModel
    {
        public string Hes { get; set; }

        public override string ToString()
        {
            return $"{Hes}";
        }        
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            string[] HesCodes = { "G1B5-6449-15", "G5B2-3442-88" };

            List<string> riskyList = new List<string>();
            List<string> risklessList = new List<string>();

            foreach (string hes in HesCodes)
            {
                var hesInstance = new HesModel();
                hesInstance.Hes = hes;

                var json = JsonConvert.SerializeObject(hesInstance);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = " https://api.saglikbakanligi.gov.tr/HES/dogrula";
                using var client = new HttpClient();

                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                JObject jsonResult = JObject.Parse(result);

                if (jsonResult["status"].ToString() == "risky")
                {
                    riskyList.Add(jsonResult["hes"].ToString());
                }
                else if (jsonResult["status"].ToString() == "riskless")
                {
                    risklessList.Add(jsonResult["hes"].ToString());
                }
            }

            foreach (var item in riskyList)
            {
                Console.WriteLine( "Riskli kod: " + item);
            }

            foreach (var item in risklessList)
            {
                Console.WriteLine("Risksiz kod: " + item);
            }

        }

    }
}
