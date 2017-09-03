using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        public ActionResult New()
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