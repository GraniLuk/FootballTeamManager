using FootballTeamManager.Models;
using FootballTeamManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FootballTeamManager.Controllers
{
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
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