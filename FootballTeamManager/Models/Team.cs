using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballTeamManager.Models
{
    public class Team   
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}