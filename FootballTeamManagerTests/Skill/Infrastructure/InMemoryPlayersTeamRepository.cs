using System.Collections.Generic;

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
