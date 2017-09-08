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
    }
}