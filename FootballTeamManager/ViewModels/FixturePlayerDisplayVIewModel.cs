using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FootballTeamManager.Models;

namespace FootballTeamManager.ViewModels
{
    public class FixturePlayerDisplayVIewModel
    {
        public DateTime Date { get; set; }
        public Team FirstTeam { get; set; }
        public Team SecondTeam { get; set; }
        public string Score { get; set; }
        public bool IsWon { get; set; }

    }
}