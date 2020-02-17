using FootballManager.Data;
using FootballManager.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace FootballTeamManager.Controllers
{
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

        // GET: Ranking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ranking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ranking/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ranking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ranking/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ranking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ranking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
