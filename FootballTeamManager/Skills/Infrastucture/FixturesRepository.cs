using FootballTeamManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FootballTeamManager.Skills.Infrastucture
{
    public class FixturesRepository : IFixturesRepository
    {
        public Task<Fixture> GetForATeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<Fixture> GetForBTeam(int teamId)
        {
            throw new NotImplementedException();
        }
    }

    public interface IFixturesRepository
    {
        Task<Fixture> GetForATeam(int teamId);
        Task<Fixture> GetForBTeam(int teamId);
    }
}