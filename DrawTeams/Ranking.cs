using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTeams
{
    public class Ranking
    {
        private Team _team;
        public Ranking(Team team)
        {
            _team = team;
        }
        public void DisplayRanking()
        {
            var ranking = _team.GetAllPlayers().OrderByDescending(a => a.Rank).ToList();
            int lastRanking = 0;
            int place = 1;
            foreach (var player in ranking)
            {
                if (lastRanking > player.Rank)
                {
                    place++;
                }
                lastRanking = player.Rank;

                Console.WriteLine(place + ". " + player.Name + " " + player.Rank);
            }
        }
    }
}
