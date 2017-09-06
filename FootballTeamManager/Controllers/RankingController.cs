using FootballTeamManager.Models;
using FootballTeamManager.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;


namespace FootballTeamManager.Controllers
{
    public class RankingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Ranking
        public ActionResult Index()
        {

            var ranking = db.Ranking.Include(x=>x.Player).Where(x=>x.RemoveDate ==null).OrderByDescending(x=>x.Wins).ToList();
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
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
