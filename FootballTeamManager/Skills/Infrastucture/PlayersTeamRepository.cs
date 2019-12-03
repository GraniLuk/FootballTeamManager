using FootballTeamManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace FootballTeamManager.Skills.Infrastucture
{
    internal class PlayersTeamRepository : IPlayersTeamRepository
    {
        private readonly ApplicationDbContext _context;
        IList<TeamPlayerAssociation> _allTeamPlayerAssociatons;
        public PlayersTeamRepository()
        {
            _context = new ApplicationDbContext();
            _allTeamPlayerAssociatons = GetAll();
        }

        private IList<TeamPlayerAssociation> GetAll()
        {
            return _context.TeamPlayerAssociations.Include(x => x.Team).Include(x=>x.Player).ToList();
        }

        public IList<TeamPlayerAssociation> GetAllTeamsForPlayer(int playerId)
        {
            return _allTeamPlayerAssociatons
                .Where(x => x.Player.Id == playerId).ToList();
        }

        public IEnumerable<Player> GetAllPlayersFromTeam(int teamId)
        {
           return (from player in _context.Players
             join teamPlayerAssociation in _context.TeamPlayerAssociations on player.Id equals teamPlayerAssociation.Player.Id
             where teamPlayerAssociation.Team.Id == teamId
             select player).ToList();
        }
    }

    public interface IPlayersTeamRepository
    {
        IList<TeamPlayerAssociation> GetAllTeamsForPlayer(int playerId);
        IEnumerable<Player> GetAllPlayersFromTeam(int teamId);
    }
}