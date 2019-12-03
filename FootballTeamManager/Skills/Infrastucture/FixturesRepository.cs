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
        public FixturesRepository()
        {
            _context = new ApplicationDbContext();
        }
        public Fixture GetForATeam(int teamId)
        {

                return _context.Fixtures.FirstOrDefault(i => i.FirstTeam.Id == teamId);
            
        }

        public Fixture GetForBTeam(int teamId)
        {
            
                return _context.Fixtures.FirstOrDefault(i => i.SecondTeam.Id == teamId);
            
        }
    }

    public interface IFixturesRepository
    {
        Fixture GetForATeam(int teamId);
        Fixture GetForBTeam(int teamId);
    }
}