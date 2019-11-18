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
            ViewBag.ShowSaveButton = (bool?)TempData["ShowSaveButton"] ?? false;
            return View(a);
        }
  
        public ActionResult ResetTeam()
        {
            Team model = new Team();
            if (ModelState.IsValid)
            {
                model.ResetTeam();
            }
            TempData["ShowSaveButton"] = false;
            return RedirectToAction("Index", "Draw");

        }

        public ActionResult NewDraw()
        {
            Team model = new Team();
            if (ModelState.IsValid)
            {
                model.DrawTeams();
            }
            TempData["ShowSaveButton"] = true;
            return RedirectToAction("Index", "Draw");

        }



    }
}