using System.Collections.Generic;
using System.Threading.Tasks;
using FootballTeamManager.Models;
using FootballTeamManager.Skills.Infrastucture;

namespace FootballTeamManagerTests.Skill.Infrastructure
{
    class InMemoryPlayersTeamRepository : IPlayersTeamRepository
    {
        public ICollection<TeamPlayerAssociation> GetAllTeamsForPlayer(int playerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
