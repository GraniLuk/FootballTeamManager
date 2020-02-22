using FootballManager.Models;
using System.Collections.Generic;

namespace FootballManager.ViewModels
{
    public class TeamDisplayViewModel
    {
        public int TeamId { get; set; }
        public List<Player> Players { get; set; }
    }
}