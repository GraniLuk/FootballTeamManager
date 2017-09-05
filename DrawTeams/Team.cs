using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTeams
{
    public class Team
    {
        private List<Player> _team;
        public Team()
        {
            _team = new List<Player>()
            {
                new Player("Łukasz Granica", 12,true),
                new Player("Mateusz Wantoch",11,true),
                new Player("Kamil Pakalski",6,true),
                new Player("Karol Skupski",11,false),
                new Player("Przemek Stolle",9,false),
                new Player("Damian Kisielewski",12,false),
                new Player("Jarek Mazur",14,true),
                new Player("Krzysztof T",9,true),
                new Player("Vitaly Skripay",14,true),
                new Player( "Łukasz Stępień",10,false),
                new Player("Łukasz Tarnowski",12,true),
                new Player( "Sylwek Plit",9,true),
                new Player("Paweł Cejrowski",6,false),
                new Player("Krzysiek Taranowski",10,true),
                new Player("Sasza od Vitaliya", 6,false),
                new Player("przemek arszulik", 7,false),
                new Player("Sadowski Karol", 5,false),
                new Player("Wojciech Ziętek", 3,false),
               new Player("Kuba Krzemiński",9,false),
                new Player("Hubert Koczergo",13,true),
               new Player("Marcin Urbaniak",10,false),
               new Player("Dorian (od Mateusza)",8,false),
                  new Player("Tomek(od Mateusza)",7,false),
                  new Player("Maciej (od Jarka)",8,false),
                  new Player("Dawid (od Jarka)",8,true),
                  new Player("Mateusz (od Łukasz)",8,true),
                  new Player("Paweł Harhaj",11,true),
                new Player("George Diegtiariow",8,false),
                new Player("Krzysiek Wołoch",4,true),
                new Player("Adrian od Mateusza",8,false)
            };
        }
       
        public List<Player> GetActivePlayers()
        {
            return _team.Where(x => x.Active).ToList();
        }

        public List<Player> GetAllPlayers()
        {
            return _team;
        }


    }
}
