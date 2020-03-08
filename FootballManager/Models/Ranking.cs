using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManager.Models
{
    public class Ranking
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Player_Id")]
        public Player Player { get; set; }

        public int Matches { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loses { get; set; }
        public int Place { get; set; }
        public int PlaceInPreviousWeek { get; set; }
        public DateTime? RemoveDate { get; set; }
    }
}