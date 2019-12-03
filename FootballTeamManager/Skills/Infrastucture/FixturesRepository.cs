using FootballTeamManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FootballTeamManager.Skills.Infrastucture
{
    public class FixturesRepository : IFixturesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly List<Fixture> _allFixtures;
        public FixturesRepository()
        {
            _context = new ApplicationDbContext();
            _allFixtures = GetAllFixtures();
        }
        public Fixture GetForATeam(int teamId)
        {

                return _allFixtures.FirstOrDefault(i => i.FirstTeam.Id == teamId);
            
        }

        public Fixture GetForBTeam(int teamId)
        {
            
                return _allFixtures.FirstOrDefault(i => i.SecondTeam.Id == teamId);
            
        }

        private List<Fixture> GetAllFixtures()
        {
            return _context.Fixtures.Include(x=>x.FirstTeam).Include(x=>x.SecondTeam).ToList();
        }
    }

    public interface IFixturesRepository
    {
        Fixture GetForATeam(int teamId);
        Fixture GetForBTeam(int teamId);


    }
}