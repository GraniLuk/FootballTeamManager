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
        public string Name { get; set; }
        private List<Player> _team;
        private ApplicationDbContext db = new ApplicationDbContext();
        
        private List<Player> secondTeam;
        private List<Player> firstTeam;

        public Team()
        {
            DrawTeams();
        }

        //public List<Player> GetActivePlayers()
        //{
        //    return _team.Where(x => x.Active).ToList();
        //}

        //public List<Player> GetAllPlayers()
        //{
        //    return _team;
        //}

        public void DrawTeams()
        {
            int firstTeamRanking = 0;
            int secondTeamRanking = 0;
            List<Player> a1;
            List<Player> b2;
            int counter = 1;

            var noTeam = db.Players.Where(x => x.TeamNumber > 0).Any();
            if (!noTeam)
            {
                do
                {
                    var zespol = db.Players.Where(x => x.Active).OrderBy(a => Guid.NewGuid()).ToList();

                    double numberOfActive = zespol.Count();
                    int teamOneNumber = Convert.ToInt32(Math.Ceiling(numberOfActive / 2.0));
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



                } while (Math.Abs(firstTeamRanking - secondTeamRanking) > 1);
                secondTeam = b2;
                firstTeam = a1;
            }
            else
            {
                firstTeam = db.Players.Where(x => x.TeamNumber == 1 && x.Active == true).ToList();
                counter = 1;
                foreach (var item in firstTeam)
                {
                    item.Id = counter ;
                    item.TeamNumber = 1;
                    counter += 1;
                }
                secondTeam= db.Players.Where(x => x.TeamNumber == 2 && x.Active == true).ToList();
                counter = 1;
                foreach (var item in secondTeam)
                {
                    item.Id = counter;
                    item.TeamNumber = 2;
                    counter += 1;
                }

            }


            


        }

        public string GetNumberOfPlayer()
        {
            return (firstTeam.Count + secondTeam.Count).ToString();
        }

        public string GetPlayerFromFirstTeam(int id)
        {
            string result = "";

            foreach (var item in firstTeam.Where(x => x.Id == id).Select(z => z.ShortName))
            {
                result= item.ToString();
            }

            //var ar = result.Split();
            //int len = 7;

            //if (ar[0].Length < 7) len = ar[0].Length;

            //StringBuilder sb = new StringBuilder();
            //sb.Append(ar[0].Substring(0, len));
            //sb.Append(ar[1].Substring(0, 1));
            // return sb.ToString();
            return result;
        }

        public string GetPlayerFromSecondTeam(int id)
        {
            string result = "";

            foreach (var item in secondTeam.Where(x => x.Id == id).Select(z => z.ShortName))
            {
                result = item.ToString();
            }


            return result;
        }
    }
}
