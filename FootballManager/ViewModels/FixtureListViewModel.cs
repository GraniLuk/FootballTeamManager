﻿using System;

namespace FootballManager.ViewModels
{
    public class FixtureListViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string FirstTeamName { get; set; }
        public int FirstTeamId { get; set; }
        public string SecondTeamName { get; set; }
        public int SecondTeamId { get; set; }
        public string Score { get; set; }
    }
}