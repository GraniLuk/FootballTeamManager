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
        public FixtureCreateViewModel()
        {

        }
        public FixtureCreateViewModel(IEnumerable<Team> allTeams)
        {
            SelectedTeamA = allTeams.Last().Id;
            SelectedTeamB = allTeams.First().Id;
            IEnumerable<SelectListItem> items = allTeams
            .Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false // or whatever
            })
            .ToList();
            TeamsAToChoose = items;
            TeamsBToChoose = items;
        }
        [Required]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;
        public IEnumerable<SelectListItem> TeamsAToChoose { get;set;}
        public int SelectedTeamA { get; set; }
        public IEnumerable<SelectListItem> TeamsBToChoose { get; set; }
        public int SelectedTeamB { get; set; }
    }
}