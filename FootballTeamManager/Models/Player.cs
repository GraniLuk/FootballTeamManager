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
        public string Name { get; set; }
        [Required]
        public int Rank { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}