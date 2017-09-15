using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballTeamManager.Models;
using FootballTeamManager.ViewModels;
using AutoMapper;

namespace FootballTeamManager.Controllers
{
    public class FixtureController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FixtureController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Fixture
        public ActionResult Index()
        {
            var fixtures = _context.Fixtures.Include(x => x.FirstTeam).Include(x => x.SecondTeam).OrderByDescending(x=>x.Date).ToList();

            return View(fixtures);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var fixture = _context.Fixtures.Single(x => x.Id == id);

            if (fixture == null)
            {
                return HttpNotFound();
            }

            return View(fixture);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg=>cfg.CreateMap<Fixture,Fixture>());
                var fixtureFromDb = _context.Fixtures.Single(x => x.Id == fixture.Id);
                Mapper.Map(fixture, fixtureFromDb);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            if (fixture == null)
            {
                return HttpNotFound();
            }

               return View(fixture);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var fixture = _context.Fixtures.Include(x=>x.FirstTeam).Include(x=>x.SecondTeam).Single(x => x.Id == id);

            var fixtureDisplayViewModel = new FixtureDisplayViewModel
            {
                Date = fixture.Date,
                FirstTeamScore = fixture.FirstTeamScore,
                SecondTeamScore = fixture.SecondTeamScore,
                FirstTeamPlayers = (from playerAssign in _context.TeamPlayerAssociations
                join player in _context.Players on playerAssign.Player.Id equals player.Id
                where playerAssign.Team.Id == fixture.FirstTeam.Id
                select player).ToList(),
                SecondTeamPlayers = (from playerAssign in _context.TeamPlayerAssociations
                    join player in _context.Players on playerAssign.Player.Id equals player.Id
                    where playerAssign.Team.Id == fixture.SecondTeam.Id
                    select player).ToList()

        };


            if (fixture.FirstTeam == null)
            {
                return HttpNotFound();
            }

            return View(fixtureDisplayViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}