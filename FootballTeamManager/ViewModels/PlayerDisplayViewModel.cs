using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FootballTeamManager.Models;

namespace FootballTeamManager.ViewModels
{
    public class PlayerDisplayViewModel
    {
        public Player Player { get; set; }
        public List<Fixture> Fixtures { get; set; }
    }
}