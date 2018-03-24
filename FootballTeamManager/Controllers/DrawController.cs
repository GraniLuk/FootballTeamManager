using FootballTeamManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballTeamManager.Controllers
{
    public class DrawController : Controller
    {
        
        // GET: Draw
        public ActionResult Index()
        {
            var a = new Team();
           
           
            return View(a);
        }
  
        public ActionResult ResetTeam()
        {
            Team model = new Team();
            if (ModelState.IsValid)
            {
                model.ResetTeam();
            }
            return RedirectToAction("Index", "Draw");

        }

        public ActionResult NewDraw()
        {
            Team model = new Team();
            if (ModelState.IsValid)
            {
                model.DrawTeams();
            }
            return RedirectToAction("Index", "Draw");

        }



    }
}