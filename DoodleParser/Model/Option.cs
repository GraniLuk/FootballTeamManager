using System;

namespace DoodleApi.Model
{
    public class Option
    {
        public object start { get; set; }
        public object end { get; set; }
        public object startDateTime { get; set; }
        public object endDateTime { get; set; }
        public bool available { get; set; }
        public DateTime ReadableDate => DateTimeOffset.FromUnixTimeMilliseconds((long)(startDateTime)).LocalDateTime;
    }
}
