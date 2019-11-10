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
        public DateTime ReadableDate => new DateTime(1969, 11, 25, 23, 00,00).AddMilliseconds((long)startDateTime);
    }
}
