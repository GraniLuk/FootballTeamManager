using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleApi.Model
{
    public class Initiator
    {
        public string name { get; set; }
        public bool notify { get; set; }
        public string timeZone { get; set; }
        public string userId { get; set; }
    }
}
