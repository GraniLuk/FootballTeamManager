using System.Collections.Generic;

namespace DoodleParser.Model
{
    public class Participant
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<int?> preferences { get; set; }
        public string smallAvatarUrl { get; set; }
        public string largeAvatarUrl { get; set; }
        public string userId { get; set; }
    }
}
