using DoodleApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoodleApi.Client
{
    public class ParticipantsService
    {
        private readonly RootObject _rootObject;
        public ParticipantsService(RootObject rootObject)
        {
            _rootObject = rootObject;
        }
        private List<Participant> GetParticipants()
        {
            return _rootObject.participants;
        }

        internal List<Participant> GetActiveParticipantsAt(DateTime date)
        {
            var option = _rootObject.options.FirstOrDefault(x => (DateTime)x.start == date);
            return new List<Participant>();
        }
    }
}
