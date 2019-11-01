using FootballTeamManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballTeamManager.ViewModels
{
    public class FixtureCreateViewModel
    {
        public DateTime Date { get; set; }
        public List<Team> TeamsAToChoose { get; set; }
        public List<Team> TeamsBToChoose { get; set; }
    }
}