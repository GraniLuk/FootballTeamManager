using FootballTeamManager.Models;
using System.Collections.Generic;

namespace FootballTeamManager.ViewModels
{
    public class TeamDisplayViewModel
    {
        public int TeamId { get; set; }
        public List<Player> Players { get; set; }
    }
}