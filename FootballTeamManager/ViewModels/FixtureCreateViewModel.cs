using FootballTeamManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballTeamManager.ViewModels
{
    public class FixtureCreateViewModel
    {
        [Required]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;
        public IEnumerable<SelectListItem> TeamsAToChoose { get;set;}
        public string SelectedTeamA { get; set; }
        public IEnumerable<SelectListItem> TeamsBToChoose { get; set; }
    }
}