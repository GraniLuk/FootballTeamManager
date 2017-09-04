﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballTeamManager.Models
{
    public class Fixture
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public Team FirstTeam { get; set; }
        public Team SecondTeam { get; set; }
        public int FirstTeamScore { get; set; }
        public int SecondTeamScore { get; set; }
    }
}