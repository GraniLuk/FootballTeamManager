using System.Collections.Generic;
using System.Threading.Tasks;
using FootballTeamManager.Models;
using FootballTeamManager.Skills.Infrastucture;

namespace FootballTeamManagerTests.Skill.Infrastructure
{
    class InMemoryPlayersTeamRepository : IPlayersTeamRepository
    {
        public IList<TeamPlayerAssociation> GetAllTeamsForPlayer(int playerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
