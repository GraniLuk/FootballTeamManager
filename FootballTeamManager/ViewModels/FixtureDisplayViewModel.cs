using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FootballTeamManager.Models;

namespace FootballTeamManager.ViewModels
{
    public class FixtureDisplayViewModel
    {
        public DateTime Date { get; set; }
        public int FirstTeamScore { get; set; }
        public int SecondTeamScore { get; set; }
        public IEnumerable<Player> FirstTeamPlayers { get; set; }
        public IEnumerable<Player> SecondTeamPlayers { get; set; }

    }
}