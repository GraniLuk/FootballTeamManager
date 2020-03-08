using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManager.Models
{
    public class TeamPlayerAssociation
    {
        public int Id { get; set; }

        [ForeignKey("Team_Id")]
        public Team Team { get; set; }

        [ForeignKey("Player_Id")]
        public Player Player { get; set; }
    }
}