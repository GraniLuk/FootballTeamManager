using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManager.Models
{
    public class Fixture
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;
        [ForeignKey("FirstTeam_Id")]
        public Team FirstTeam { get; set; }
        [ForeignKey("SecondTeam_Id")]
        public Team SecondTeam { get; set; }
        public int FirstTeamScore { get; set; }
        public int SecondTeamScore { get; set; }
        public int Season { get; set; }
    }
}