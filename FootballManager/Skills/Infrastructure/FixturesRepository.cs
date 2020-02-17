using FootballManager.Models;
using FootballManager.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FootballManager.Skills.Infrastructure
{
    public class FixturesRepository : IFixturesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly List<Fixture> _allFixtures;
        public FixturesRepository(ApplicationDbContext context)
        {
            _context = context;
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
            return _context.Fixtures.Include(x => x.FirstTeam).Include(x => x.SecondTeam).ToList();
        }
    }

    public interface IFixturesRepository
    {
        Fixture GetForATeam(int teamId);
        Fixture GetForBTeam(int teamId);


    }
}