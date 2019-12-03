using System.Collections.Generic;
using System.Threading.Tasks;
using FootballTeamManager.Models;
using FootballTeamManager.Skills.Infrastucture;

namespace FootballTeamManagerTests.Skill.Infrastructure
{
    class InMemoryPlayersTeamRepository : IPlayersTeamRepository
    {
        public IEnumerable<Player> GetAllPlayersFromTeam(int teamId)
        {
            throw new System.NotImplementedException();
        }

        public IList<TeamPlayerAssociation> GetAllTeamsForPlayer(int playerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
