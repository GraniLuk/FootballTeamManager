using FootballManager.Models;
using FootballManager.Data;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.Skills.Infrastructure
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;
        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
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