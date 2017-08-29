using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballTeamManager.Models;

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
            var fixtures = _context.Fixtures.Include(x => x.FirstTeam).Include(x => x.SecondTeam).ToList();

            return View(fixtures);
        }

        public ActionResult New()
        {
            return View();
        }
    }
}