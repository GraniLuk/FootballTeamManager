using FootballTeamManager.Models;
using FootballTeamManager.ViewModels;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FootballTeamManager.Controllers
{
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TeamController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        // GET: Team
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exam = _db.Players.ToList();

            var teamDisplayViewModel = new TeamDisplayViewModel()
            {
                TeamId = id.Value,
                Players = (from player in _db.Players
                           join teamPlayerAssociation in _db.TeamPlayerAssociations on player.Id equals teamPlayerAssociation.Player.Id
                           where teamPlayerAssociation.Team.Id == id.Value
                           select player).ToList()
            };
            
            return View(teamDisplayViewModel);
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