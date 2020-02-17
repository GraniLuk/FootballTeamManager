using FootballManager.Data;
using FootballManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.Controllers
{
    public class DrawController : Controller
    {
        private readonly ApplicationDbContext context;

        public DrawController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Draw
        public ActionResult Index()
        {
            ViewBag.ShowSaveButton = (bool?)TempData["ShowSaveButton"] ?? false;
            return View(new Draw(context));
        }

        public ActionResult ResetTeam()
        {
            var model = new Draw(context);
            if (ModelState.IsValid)
            {
                model.ResetTeam();
            }
            TempData["ShowSaveButton"] = false;
            return RedirectToAction("Index", "Draw");

        }

        public ActionResult NewDraw()
        {
            var model = new Draw(context);
            if (ModelState.IsValid)
            {
                model.DrawTeams();
            }
            TempData["ShowSaveButton"] = true;
            return RedirectToAction("Index", "Draw");

        }



    }
}