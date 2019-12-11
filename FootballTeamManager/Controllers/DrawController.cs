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
            ViewBag.ShowSaveButton = (bool?)TempData["ShowSaveButton"] ?? false;
            return View(new Draw());
        }
  
        public ActionResult ResetTeam()
        {
            var model = new Draw();
            if (ModelState.IsValid)
            {
                model.ResetTeam();
            }
            TempData["ShowSaveButton"] = false;
            return RedirectToAction("Index", "Draw");

        }

        public ActionResult NewDraw()
        {
            var model = new Draw();
            if (ModelState.IsValid)
            {
                model.DrawTeams();
            }
            TempData["ShowSaveButton"] = true;
            return RedirectToAction("Index", "Draw");

        }



    }
}