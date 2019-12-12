using FootballTeamManager.Models;
using System.Data.Entity;
namespace FootballTeamManager.Skills.Infrastucture
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;
        public PlayerRepository()
        {
            _context = new ApplicationDbContext();
        }
        public void Update(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }

    public interface IPlayerRepository
    {
        void Update(Player player);
    }
}