using FootballTeamManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballTeamManager.Skills.Infrastucture
{
    internal class PlayersTeamRepository : IPlayersTeamRepository
    {
        public Task<ICollection<TeamPlayerAssociation>> GetAllTeamsForPlayer(int playerId)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IPlayersTeamRepository
    {
        Task<ICollection<TeamPlayerAssociation>> GetAllTeamsForPlayer(int playerId);
    }
}