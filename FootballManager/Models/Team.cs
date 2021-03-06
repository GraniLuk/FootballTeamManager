﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [StringLength(12)]
        public string Name { get; set; }

        public static Team CreateForDate(string Name, DateTime date)
        {
            return new Team() { Name = date.ToShortDateString() + Name };
        }
    }
}
