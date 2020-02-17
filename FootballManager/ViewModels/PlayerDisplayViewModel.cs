using FootballManager.Models;
using System.Collections.Generic;

namespace FootballManager.ViewModels
{
    public class PlayerDisplayViewModel
    {
        public Player Player { get; set; }
        public List<FixturePlayerDisplayVIewModel> Fixtures { get; set; }
    }
}