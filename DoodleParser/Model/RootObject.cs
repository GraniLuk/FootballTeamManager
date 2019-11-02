using System.Collections.Generic;

namespace DoodleParser.Model
{
    public class RootObject
    {
        public string id { get; set; }
        public long latestChange { get; set; }
        public long initiated { get; set; }
        public int participantsCount { get; set; }
        public int inviteesCount { get; set; }
        public string type { get; set; }
        public bool timeZone { get; set; }
        public int columnConstraint { get; set; }
        public string preferencesType { get; set; }
        public string state { get; set; }
        public string locale { get; set; }
        public string title { get; set; }
        public Initiator initiator { get; set; }
        public List<Option> options { get; set; }
        public string optionsHash { get; set; }
        public List<Participant> participants { get; set; }
        public string device { get; set; }
        public List<object> calendarEvents { get; set; }
        public string levels { get; set; }
    }
}
