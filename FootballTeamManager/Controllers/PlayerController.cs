using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballTeamManager.Models;
using FootballTeamManager.ViewModels;

namespace FootballTeamManager.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Players
        public ActionResult Index()
        {
            return View(db.Players.ToList());
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var playerDisplayViewModel = new PlayerDisplayViewModel {Player = db.Players.Find(id)};

            var playerTeams = db.TeamPlayerAssociations.Where(team => team.Player.Id == id).Select(x => x.Team.Id)
                .ToList();

            var fixturesInFirstTeam = db.Fixtures
                .Include(t=>t.FirstTeam)
                .Include(t=>t.SecondTeam)
                .Where(t => playerTeams.Contains(t.FirstTeam.Id))
                .Select(t => new FixturePlayerDisplayVIewModel()
                           {
                               Date = t.Date,
                               FirstTeam = t.FirstTeam,
                               SecondTeam = t.SecondTeam,
                               Score = t.FirstTeamScore.ToString() + ":" + t.SecondTeamScore.ToString(),
                               IsWon = t.FirstTeamScore>t.SecondTeamScore
                           });

           var fixturesInSecondTeam = db.Fixtures
          .Include(t => t.FirstTeam)
          .Include(t => t.SecondTeam)
          .Where(t => playerTeams.Contains(t.SecondTeam.Id))
          .Select(t => new FixturePlayerDisplayVIewModel()
          {
              Date = t.Date,
              FirstTeam = t.FirstTeam,
              SecondTeam = t.SecondTeam,
              Score = t.FirstTeamScore.ToString() + ":" + t.SecondTeamScore.ToString(),
              IsWon = t.FirstTeamScore < t.SecondTeamScore
          });

            var fixtures = fixturesInFirstTeam.Concat(fixturesInSecondTeam).OrderByDescending(x=>x.Date);

            playerDisplayViewModel.Fixtures = fixtures.ToList();

            if (playerDisplayViewModel.Player == null)
            {
                return HttpNotFound();
            }
            return View(playerDisplayViewModel);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Skill,Active,ShortName")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Skill,Active,ShortName")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
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
