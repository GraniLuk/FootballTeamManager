using System;
using System.Collections.Generic;
using DoodleApi.Model;
using DoodleApi.Client;

namespace DoodleApi
{
    public class DoodleApi : IApi
    {
        private readonly string DoodleUrl;

        public DoodleApi(string doodleUrl)
        {
            DoodleUrl = doodleUrl;
        }

        public List<Participant> GetActivePlayersAt(DateTime date)
        {
            var rootObjectClient = new RootObjectClient(DoodleUrl);
            var rootObject = rootObjectClient.GetRootObject();
            var participantsService = new ParticipantsService(rootObject);
            return participantsService.GetActiveParticipantsAt(date);
        }
    }
}
