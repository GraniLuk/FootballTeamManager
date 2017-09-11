using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FootballTeamManager.Models
{
    public class Player
    {
        public Player()
        {
            Active = true;
           // DrawTeams();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        public int Skill { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        [StringLength(7)]
        public string ShortName { get; set; }
        public Int16 TeamNumber { get; set; }

        private List<Player> _team;
        private List<Player> secondTeam;
        private List<Player> firstTeam;
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Player> GetFirstTeam()
        {
            
            //int firstTeamRanking = 0;
            //int secondTeamRanking = 0;
            //List<Player> a1;
            //List<Player> b2;
            //int counter = 0;

            //do
            //{
            //    var zespol = db.Players.Where(x => x.Active).OrderBy(a => Guid.NewGuid()).ToList();
            //    a1 = zespol.Take(7).ToList();
            //     b2 = Enumerable.Reverse(zespol).Take(7).Reverse().ToList();
            //    firstTeamRanking = 0;
            //    secondTeamRanking = 0;

            //    foreach (var item in a1)
            //    {

            //        firstTeamRanking += item.Skill;
            //        item.TeamNumber = 1;
            //    }

            //    foreach (var item in b2)
            //    {

            //        secondTeamRanking += item.Skill;
            //        item.TeamNumber = 2;
            //    }

            //    counter += 1;
               
            //} while (Math.Abs(firstTeamRanking - secondTeamRanking) > 1);

            // a1.AddRange(b2);

            return firstTeam;

            
        }
        public List<Player> GetSecondTeam()
        {
            return secondTeam;
        }

        public string GetPlayer(int Id,int team)
        {
            string result="";
            switch (team)
            {
                case 1:
                    result = firstTeam.Where(x => x.Id == 1).Select(x => x.Name).ToString();
                    break;
                default:
                    break;
            }

            return result;
        }

        public void DrawTeams()
        {
            int firstTeamRanking = 0;
            int secondTeamRanking = 0;
            List<Player> a1;
            List<Player> b2;
            int counter = 0;

            do
            {
                var zespol = db.Players.Where(x => x.Active).OrderBy(a => Guid.NewGuid()).ToList();
                a1 = zespol.Take(7).ToList();
                b2 = Enumerable.Reverse(zespol).Take(7).Reverse().ToList();
                firstTeamRanking = 0;
                secondTeamRanking = 0;

                foreach (var item in a1)
                {

                    firstTeamRanking += item.Skill;
                    item.TeamNumber = 1;
                }

                foreach (var item in b2)
                {

                    secondTeamRanking += item.Skill;
                    item.TeamNumber = 2;
                }

                counter += 1;

            } while (Math.Abs(firstTeamRanking - secondTeamRanking) > 1);


            secondTeam = b2;
            firstTeam = a1;

           
        }


    }
}