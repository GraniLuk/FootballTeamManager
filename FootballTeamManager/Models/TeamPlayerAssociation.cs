namespace FootballTeamManager.Models
{
    public class TeamPlayerAssociation
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public Player Player { get; set; }
    }
}