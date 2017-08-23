using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTeams
{
    public class Player
    {
        public Player(string name, int rank, bool active)
        {
            Name = name;
            Rank = rank;
            Active = active;
        }
        public string Name { get; set; }
        public int Rank { get; set; }
        public bool Active { get; set; }
    }
}
