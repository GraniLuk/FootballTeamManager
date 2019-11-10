using DoodleApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;

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
            return JsonConvert.DeserializeObject<RootObject>(responseString);
        }

    }
}
