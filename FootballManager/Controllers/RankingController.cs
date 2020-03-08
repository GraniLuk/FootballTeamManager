using FootballManager.Data;
using FootballManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FootballTeamManager.Controllers {
    public class RankingController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RankingController(ApplicationDbContext context)
        {
            _db = context;
        }
        // GET: Ranking
        public ActionResult Index()
        {
            var ranking = _db.Ranking
                .Include(x => x.Player)
                .Where(x => x.RemoveDate == null)
                .OrderByDescending(x => x.Wins)
                .Select(x => new RankingDisplayViewModel() { PlayerRanking = x, Player = x.Player })
                .ToList();

            return View(ranking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
