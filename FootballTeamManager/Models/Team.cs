using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

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

            do
            {
                var zespol = db.Players.Where(x => x.Active).OrderBy(a => Guid.NewGuid()).ToList();
                a1 = zespol.Take(7).ToList();
                b2 = Enumerable.Reverse(zespol).Take(7).Reverse().ToList();
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

        public string GetPlayerFromFirstTeam(int id)
        {
            string result = "pustyString";

            foreach (var item in firstTeam.Where(x => x.Id == id).Select(z => z.Name))
            {
                result= item.ToString();
            }

            var ar = result.Split();
            int len = 7;
          
            if (ar[0].Length < 7) len = ar[0].Length;

            StringBuilder sb = new StringBuilder();
            sb.Append(ar[0].Substring(0, len));
            sb.Append(ar[1].Substring(0, 1));


            return sb.ToString();
        }

        public string GetPlayerFromSecondTeam(int id)
        {
            string result = "";

            foreach (var item in secondTeam.Where(x => x.Id == id).Select(z => z.Name))
            {
                result = item.ToString();
            }


            return result.Substring(0, 7);
        }
    }
}
