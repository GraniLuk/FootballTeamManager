using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTeams
{
    public class Draw
    {
        private Team _team;
        public Draw(Team team)
        {
            _team = team;
        }
        public void DrawTeams()
        {
            int firstTeamRanking = 0;
            int secondTeamRanking = 0;
            do
            {
                var pomieszani = _team.GetActivePlayers().OrderBy(a => Guid.NewGuid()).ToList();
                firstTeamRanking = 0;
                secondTeamRanking = 0;
                var firstTeam = pomieszani.Take(_team.GetActivePlayers().Count / 2);

                var secondTeam = Enumerable.Reverse(pomieszani).Take(_team.GetActivePlayers().Count / 2).Reverse().ToList();

                Console.WriteLine("Pierwsza Drużyna:");
                foreach (var item in firstTeam)
                {
                    Console.WriteLine(item.Name + " " + item.Rank);
                    firstTeamRanking += item.Rank;
                }
                Console.WriteLine(firstTeamRanking);
                Console.WriteLine("Druga Drużyna:");
                foreach (var item in secondTeam)
                {
                    Console.WriteLine(item.Name + " " + item.Rank);
                    secondTeamRanking += item.Rank;
                }
                Console.WriteLine(secondTeamRanking);

            } while (Math.Abs(firstTeamRanking - secondTeamRanking) > 1);
        }
    }
}
