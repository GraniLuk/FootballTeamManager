using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballTeamManager.Models
{
    public class Team   
    {
        public int Id { get; set; }
        [Required]
        [StringLength(12)]
        public string Name { get; set; }
        public List<Player> Players { get; set; }      

        public static Team CreateForDate(string Name, DateTime date)
        {
            return new Team() { Name = date.ToShortDateString() + Name };
        }
    }
}
