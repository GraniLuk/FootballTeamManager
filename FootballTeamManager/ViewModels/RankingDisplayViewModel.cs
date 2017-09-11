using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FootballTeamManager.Models;

namespace FootballTeamManager.ViewModels
{
    public class RankingDisplayViewModel
    {
        public Ranking PlayerRanking { get; set; }
        public Player Player { get; set; }        
        public Change Change { get; set; }
    }

    public enum Change  
    {
        Increase, Fall, Maintain
    }
}