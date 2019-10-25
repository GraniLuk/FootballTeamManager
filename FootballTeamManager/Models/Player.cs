using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FootballTeamManager.Models
{
    public class Player
    {
        public Player()
        {
            Active = true;
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
        public short TeamNumber { get; set; }
        public short Lp { get; set; }
        [StringLength(30)]
        public string DoodleName { get; set; }
    }
}