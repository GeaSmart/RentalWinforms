using Mach.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;


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

        public static async Task<string> Post(Contrato contrato)
        {
            using (HttpClient client = new HttpClient())
            {
                var myContent = JsonConvert.SerializeObject(contrato);
                var bytecontent = new ByteArrayContent(Encoding.UTF8.GetBytes(myContent));
                bytecontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                using (HttpResponseMessage res = await client.PostAsync(baseURL, bytecontent))
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

        public static async Task<string> Put(int id, Contrato contrato)
        {
            using (HttpClient client = new HttpClient())
            {
                var myContent = JsonConvert.SerializeObject(contrato);
                var bytecontent = new ByteArrayContent(Encoding.UTF8.GetBytes(myContent));
                bytecontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                using (HttpResponseMessage res = await client.PutAsync(baseURL + $"/{id}",bytecontent))
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

        public static async Task<string> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync(baseURL + $"/{id}"))
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
