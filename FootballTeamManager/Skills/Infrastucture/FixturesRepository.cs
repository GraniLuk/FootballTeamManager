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
        public Task<Fixture> GetForATeam(int teamId)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Fixtures.FirstOrDefaultAsync(i => i.FirstTeam.Id == teamId);
            }
        }

        public Task<Fixture> GetForBTeam(int teamId)
        {
            using (var db = new ApplicationDbContext())
            {
                return _context.Fixtures.FirstOrDefaultAsync(i => i.SecondTeam.Id == teamId);
            }
        }
    }

    public interface IFixturesRepository
    {
        Task<Fixture> GetForATeam(int teamId);
        Task<Fixture> GetForBTeam(int teamId);
    }
}