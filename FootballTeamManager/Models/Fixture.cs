using System;
using System.Linq;
using System.Web;

namespace FootballTeamManager.Models
{
    public class Fixture
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Team FirstTeam { get; set; }
        public Team SecondTeam { get; set; }
        public int FirstTeamScore { get; set; }
        public int SecondTeamScore { get; set; }
    }
}