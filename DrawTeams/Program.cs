using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTeams
{
    public class Program
    {
        private static void Main(string[] args)
        {
           
            var team = new Team();
            while (true)
            {
                Console.WriteLine("Type D to draw squads, R to display Ranking, E to exit application");
                switch (Console.ReadLine())
            {
                case "D":
                    new Draw(team).DrawTeams();
                    break;
                case "R":
                    new Ranking(team).DisplayRanking();
                    break;
                case "E":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            }



        }

       
    }
}
