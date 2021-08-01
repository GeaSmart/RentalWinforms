using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mach.Shared
{
    public static class ApiHelper
    {
        private static readonly string baseURL = @"https://localhost:44329/api/contrato";
        public static async Task<string> GetAll()
        {
            using(HttpClient client = new HttpClient())
            {
                using(HttpResponseMessage res = await client.GetAsync(baseURL))
                {
                    using(HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }

        public static async Task<string> Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + $"/{id}"))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }


        public static string BeautifyJson(string jsonString)
        {
            JToken parseJson = JToken.Parse(jsonString);
            return parseJson.ToString(Formatting.Indented);
        }


    }
}
