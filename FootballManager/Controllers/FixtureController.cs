using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FootballManager.Data;
using FootballManager.Models;
using FootballManager.Skills.App;
using FootballManager.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.Controllers
{
    public class FixtureController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FixtureController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var fixtures = _context.Fixtures
                .Include(x => x.FirstTeam)
                .Include(x => x.SecondTeam)
                .OrderByDescending(x => x.Date)
                .Select(x => new FixtureListViewModel()
                {
                    Id = x.Id,
                    Date = x.Date,
                    FirstTeamId = x.FirstTeam.Id,
                    FirstTeamName = x.FirstTeam.Name,
                    SecondTeamId = x.SecondTeam.Id,
                    SecondTeamName = x.SecondTeam.Name,
                    Score = x.FirstTeamScore.ToString() + ":" + x.SecondTeamScore.ToString()
                });

            if (fixtures == null)
            {
                return NotFound();
            }

            return View(fixtures.ToList());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var fixture = _context.Fixtures.Single(x => x.Id == id);

            if (fixture == null)
            {
                return NotFound();
            }

            return View(fixture);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Fixture, Fixture>()
                .ForMember(dest => dest.FirstTeam, opts => opts.Ignore())
                .ForMember(dest => dest.SecondTeam, opts => opts.Ignore()));
                var fixtureFromDb = _context.Fixtures.Include(x => x.FirstTeam).Include(x => x.SecondTeam).Single(x => x.Id == fixture.Id);
                var scoreChanged = fixtureFromDb.FirstTeamScore != fixture.FirstTeamScore;
                config.CreateMapper().Map(fixture, fixtureFromDb);
                _context.SaveChanges();
                if (scoreChanged)
                {
                    var updateSkillService = new UpdateSkillService(_context);
                    updateSkillService.UpdateSkillForAllParticipants(fixtureFromDb);
                    var result = _context.Database.ExecuteSqlRaw("EXECUTE [dbo].[sp_Ranking_Aktualizuj]");
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }

            if (fixture == null)
            {
                return NotFound();
            }

            return View(fixture);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var fixture = _context.Fixtures.Include(x => x.FirstTeam).Include(x => x.SecondTeam).Single(x => x.Id == id);

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
                return NotFound();
            }

            return View(fixtureDisplayViewModel);
        }

        public ActionResult Create()
        {
            return View(new Fixture());
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create(Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                var teamA = Team.CreateForDate("A", fixture.Date);
                _context.Teams.Add(teamA);
                var teamB = Team.CreateForDate("B", fixture.Date);
                _context.Teams.Add(teamA);
                _context.SaveChanges();
                var teamPlayersA = Draw.SetPlayersFromDraw(teamA, _context.Players.Where(x => x.TeamNumber == 1));
                var teamPlayersB = Draw.SetPlayersFromDraw(teamB, _context.Players.Where(x => x.TeamNumber == 2));
                _context.TeamPlayerAssociations.AddRange(teamPlayersA);
                _context.TeamPlayerAssociations.AddRange(teamPlayersB);
                _context.SaveChanges();
                fixture.FirstTeam = teamA;
                fixture.SecondTeam = teamB;
                _context.Fixtures.Add(fixture);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fixture);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}