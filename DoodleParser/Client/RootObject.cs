using DoodleApi.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace DoodleApi.Client
{
    public class RootObjectClient
    {
        public RootObjectClient(string doodleUrl)
        {
            DoodleUrl = doodleUrl;
        }

        private static readonly HttpClient client = new HttpClient();
        private readonly string DoodleUrl;

        public RootObject GetRootObject()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Uri url = new Uri(DoodleUrl);
            var responseString = client.GetStringAsync(url).Result;
            return JsonSerializer.Deserialize<RootObject>(responseString);
        }

    }
}
