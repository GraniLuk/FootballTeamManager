using System;

namespace FootballTeamManager.Models
{

    public class Ranking
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Player Player { get; set; }
        public int Matches { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loses { get; set; }
        public int Place { get; set; }
        public DateTime? RemoveDate { get; set; }
    }
}