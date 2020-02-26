using System;

namespace DoodleApi.Model
{
    public class Option
    {
        public long start { get; set; }
        public long end { get; set; }
        public long startDateTime { get; set; }
        public long endDateTime { get; set; }
        public bool available { get; set; }
        public DateTime ReadableDate => DateTimeOffset.FromUnixTimeMilliseconds(startDateTime).LocalDateTime;
    }
}
