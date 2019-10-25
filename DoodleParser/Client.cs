using FootballTeamManagerTests.DoodleApi;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace DoodleParser
{
    public class Client
    {
        private static readonly HttpClient client = new HttpClient();

        public List<Participant> GetParticipants(string uri)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Uri url = new Uri(uri);
            var responseString = client.GetStringAsync(uri).Result;
            return JsonConvert.DeserializeObject<RootObject>(responseString).participants;
        }
    }
}
