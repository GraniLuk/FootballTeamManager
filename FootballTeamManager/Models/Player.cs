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
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        public int Skill { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}