﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FootballTeamManager.Models
{
    public class Player
    {
        public Player()
        {
            Active = true;
           // DrawTeams();
        }
        public int Id { get; set; }
        [Required]
        [DisplayName("Piłkarz")]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        public int Skill { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        [StringLength(7)]
        public string ShortName { get; set; }
        public Int16 TeamNumber { get; set; }
        public Int16 Lp { get; set; }
    }
}