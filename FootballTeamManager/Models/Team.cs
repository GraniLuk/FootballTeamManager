using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using static System.Math;

namespace FootballTeamManager.Models
{
    public class Team   
    {
        public int Id { get; set; }
        [Required]
        [StringLength(12)]
        public string Name { get; set; }
        private List<Player> _team;
        private ApplicationDbContext db = new ApplicationDbContext();
        
        private List<Player> _secondTeam;
        private List<Player> _firstTeam;

        public Team()
        {
            DrawTeams();
        }

        public void DrawTeams()
        {
            int counter;

            var noTeam = db.Players.Any(x => x.TeamNumber > 0);
            if (!noTeam)
            {
                int firstTeamRanking;
                int secondTeamRanking;
                List<Player> a1;
                List<Player> b2;
                do
                {
                    var zespol = db.Players.Where(x => x.Active).OrderBy(a => Guid.NewGuid()).ToList();
                    double numberOfActive = zespol.Count();
                    int teamOneNumber = Convert.ToInt32(Ceiling(numberOfActive / 2.0));
                    int teamTwoNumber = Convert.ToInt32(numberOfActive) - teamOneNumber;

                    a1 = zespol.Take(teamOneNumber).ToList();
                    b2 = Enumerable.Reverse(zespol).Take(teamTwoNumber).Reverse().ToList();
                    firstTeamRanking = 0;
                    secondTeamRanking = 0;

                    counter = 1;
                    foreach (var item in a1)
                    {

                        firstTeamRanking += item.Skill;
                        item.TeamNumber = 1;
                        item.Id = counter;
                        counter += 1;
                    }
                    counter = 1;
                    foreach (var item in b2)
                    {

                        secondTeamRanking += item.Skill;
                        item.TeamNumber = 2;
                        item.Id = counter;
                        counter += 1;
                    }
                } while (Abs(firstTeamRanking - secondTeamRanking) > 1);
                _secondTeam = b2;
                _firstTeam = a1;
            }
            else
            {
                _firstTeam = db.Players.Where(x => x.TeamNumber == 1 && x.Active).ToList();
                counter = 1;
                foreach (var item in _firstTeam)
                {
                    item.Id = counter ;
                    item.TeamNumber = 1;
                    counter += 1;
                }
                _secondTeam= db.Players.Where(x => x.TeamNumber == 2 && x.Active).ToList();
                counter = 1;
                foreach (var item in _secondTeam)
                {
                    item.Id = counter;
                    item.TeamNumber = 2;
                    counter += 1;
                }

            }
        }

        public string GetNumberOfPlayer()
        {
            return (_firstTeam.Count + _secondTeam.Count).ToString();
        }

        public string GetPlayerFromFirstTeam(int id)
        {
            var result = "";

            foreach (var item in _firstTeam.Where(x => x.Id == id).Select(z => z.ShortName))
            {
                result= item;
            }
            return result;
        }

        public string GetPlayerFromSecondTeam(int id)
        {
            string result = "";

            foreach (var item in _secondTeam.Where(x => x.Id == id).Select(z => z.ShortName))
            {
                result = item;
            }

            return result;
        }
    }
}
