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
            using(var client = new HttpClient())
            {
                var endpoint = new Uri("https://api.saglikbakanligi.gov.tr/HES/dogrula");
            }
        }
    }
}
