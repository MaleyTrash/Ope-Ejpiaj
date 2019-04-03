using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Ejpiaj
{
    public class ApiWrap
    {
        public readonly string Board;

        private readonly HttpClient client;
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        public ApiWrap(string board)
        {
            Board = board;

            client = new HttpClient();
            client.BaseAddress = new Uri($"https://8ch.net/{board}/");
        }

        public async Task<Catalog[]> GetCatalog()
        {
            var res = await client.GetAsync("catalog.json");

            string data = await res.Content.ReadAsStringAsync();

            Catalog[] cat = serializer.Deserialize<Catalog[]>(data);

            return cat;
        }

        public async Task<Thread> GetThread(string id)
        {
            var res = await client.GetAsync($"res/{id}.json");

            string data = await res.Content.ReadAsStringAsync();

            Thread thr = serializer.Deserialize<Thread>(data);

            return thr;
        }
    }
}
