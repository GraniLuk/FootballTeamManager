using FootballTeamManagerTests.DoodleApi;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace DoodleParser
{
    public class Client
    {
        private static readonly HttpClient client = new HttpClient();

        const string DoodleUrl = "http://doodle.com/api/v2.0/polls/vxmqh3weap4az3cu/";

        public List<Participant> GetParticipants()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Uri url = new Uri(DoodleUrl);
            var responseString = client.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<RootObject>(responseString).participants;
        }

        public List<Participant> GetActivePlayers()
        {
            return GetParticipants().Where(x => x.preferences.LastOrDefault() == 1).ToList();
        }
            
    }
}
