using FootballTeamManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace FootballTeamManager.Skills.Infrastucture
{
    internal class PlayersTeamRepository : IPlayersTeamRepository
    {
        private readonly ApplicationDbContext _context;
        public PlayersTeamRepository()
        {
            _context = new ApplicationDbContext();
        }

        public ICollection<TeamPlayerAssociation> GetAllTeamsForPlayer(int playerId)
        {
            return _context.TeamPlayerAssociations.Include(x=>x.Team)
                .Where(x => x.Player.Id == playerId).ToList();
        }
    }

    public interface IPlayersTeamRepository
    {
        ICollection<TeamPlayerAssociation> GetAllTeamsForPlayer(int playerId);
    }
}