﻿using DoodleApi;
using FootballManager.Data;
using FootballManager.Models;
using FootballManager.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Globalization;
using System.Linq;

namespace FootballManager.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IApi _doodleParser;

        public PlayerController(IApi client, ApplicationDbContext dbContext)
        {
            _doodleParser = client;
            _db = dbContext;
        }

        // GET: Players
        public ActionResult Index()
        {
            ViewBag.totalActive = _db.Players.Count(x => x.Active);
            return View(_db.Players.ToList());
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var playerDisplayViewModel = new PlayerDisplayViewModel { Player = _db.Players.Find(id) };

            var playerTeams = _db.TeamPlayerAssociations.Where(team => team.Player.Id == id).Select(x => x.Team.Id)
                .ToList();

            var fixturesInFirstTeam = _db.Fixtures
                .Include(t => t.FirstTeam)
                .Include(t => t.SecondTeam)
                .Where(t => playerTeams.Contains(t.FirstTeam.Id))
                .Select(
                    t => new
                    {
                        t.Date,
                        t.FirstTeam,
                        t.SecondTeam,
                        Score = t.FirstTeamScore.ToString(CultureInfo.InvariantCulture) + ":" + t.SecondTeamScore.ToString(CultureInfo.InvariantCulture),
                        IsWon = t.FirstTeamScore > t.SecondTeamScore
                    })
                .AsEnumerable()
                .Union(_db.Fixtures
                .Include(t => t.FirstTeam)
                .Include(t => t.SecondTeam)
                .Where(t => playerTeams.Contains(t.SecondTeam.Id))
                .Select(
                    t => new
                    {
                        t.Date,
                        t.FirstTeam,
                        t.SecondTeam,
                        Score = t.FirstTeamScore.ToString(CultureInfo.InvariantCulture) + ":" + t.SecondTeamScore.ToString(CultureInfo.InvariantCulture),
                        IsWon = t.SecondTeamScore > t.FirstTeamScore
                    })
                )
                .OrderByDescending(x => x.Date)
                .Select(t => new FixturePlayerDisplayVIewModel()
                {
                    Date = t.Date,
                    FirstTeam = t.FirstTeam,
                    SecondTeam = t.SecondTeam,
                    Score = t.Score,
                    IsWon = t.IsWon
                })
                
                .ToList();

            playerDisplayViewModel.Fixtures = fixturesInFirstTeam;

            if (playerDisplayViewModel.Player == null)
            {
                return NotFound();
            }
            return View(playerDisplayViewModel);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                _db.Players.Add(player);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var player = _db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(Player player)
        {
            if (!ModelState.IsValid) return View(player);
            _db.Entry(player).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var player = _db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = _db.Players.Find(id);
            _db.Players.Remove(player);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult DoodleRefresh(DateTime date)
        {
            var activePlayers = _doodleParser.GetActivePlayersAt(date);

            foreach (var player in _db.Players)
            {
                player.SetAsActiveBasedOnDoodleList(activePlayers);
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
