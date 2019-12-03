﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FootballTeamManager.Models
{
    public class Draw
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private List<Player> _secondTeam;
        private List<Player> _firstTeam;



        public Draw()
        {
            GetExistingSquad();
        }

        public static IEnumerable<TeamPlayerAssociation> SetPlayersFromDraw(Team team,IEnumerable<Player> players)
        {
            return players.Select(x => new TeamPlayerAssociation() { Team = team, Player = x });
        }

        public void ResetTeam()
        {
            try
            {
                var players = db.Players.Where(x => x.TeamNumber > 0);

                foreach (var player in players)
                {
                    player.TeamNumber = 0;
                    db.Entry(player).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                var a = ex.Message;
                throw;
            }

        }

        public void DrawTeams()
        {
            var IsAnyTeam = db.Players.Any(x => x.TeamNumber > 0);
            if (!IsAnyTeam)
            {
                StartDrawNewSquad();
                SaveSquadToDatabase();
            }
            else
            {
                GetExistingSquad();
            }
        }

        private void SaveSquadToDatabase()
        {
            /*
             var players = db.Players.Where(x => x.TeamNumber >0);
                
                foreach (var player in players)
                {
                    player.TeamNumber = 0;
                    db.Entry(player).State = EntityState.Modified;
                }
                db.SaveChanges();
             */

            if (_firstTeam.Count > 0)
            {

                foreach (var item in _firstTeam)
                {
                    var player = db.Players.Find(item.Id);
                    player.TeamNumber = 1;
                    db.Entry(player).State = EntityState.Modified;
                }
                db.SaveChanges();

            }
            if (_secondTeam.Count > 0)
            {

                foreach (var item in _secondTeam)
                {
                    var player = db.Players.Find(item.Id);
                    player.TeamNumber = 2;
                    db.Entry(player).State = EntityState.Modified;
                }
                db.SaveChanges();

            }

        }

        private void GetExistingSquad()
        {
            short counter;
            _firstTeam = db.Players.Where(x => x.TeamNumber == 1 && x.Active).ToList();
            counter = 1;
            foreach (var item in _firstTeam)
            {
                item.Lp = counter;
                item.TeamNumber = 1;
                counter += 1;
            }
            _secondTeam = db.Players.Where(x => x.TeamNumber == 2 && x.Active).ToList();
            counter = 1;
            foreach (var item in _secondTeam)
            {
                item.Lp = counter;
                item.TeamNumber = 2;
                counter += 1;
            }
        }

        private void StartDrawNewSquad()
        {
            short counter;
            int firstTeamRanking;
            int secondTeamRanking;
            List<Player> a1;
            List<Player> b2;
            var differenceBetweenSkillsInTeams = 1;
            var drawsCount = 0;
            do
            {
                drawsCount++;
                var zespol = db.Players.Where(x => x.Active).OrderBy(a => Guid.NewGuid()).ToList();
                double numberOfActive = zespol.Count();
                int teamOneNumber = Convert.ToInt32(Math.Ceiling(numberOfActive / 2.0));
                int teamTwoNumber = Convert.ToInt32(numberOfActive) - teamOneNumber;

                a1 = zespol.Take(teamOneNumber).ToList();
                b2 = Enumerable.Reverse(zespol).Take(teamTwoNumber).Reverse().ToList();
                firstTeamRanking = 0;
                secondTeamRanking = 0;

                counter = 1;
                foreach (var item in a1)
                {

                    firstTeamRanking += item.Skill;
                    item.TeamNumber = 1;
                    item.Lp = counter;
                    counter += 1;
                }
                counter = 1;
                foreach (var item in b2)
                {

                    secondTeamRanking += item.Skill;
                    item.TeamNumber = 2;
                    item.Lp = counter;
                    counter += 1;
                }
                if (drawsCount % 10 == 0) differenceBetweenSkillsInTeams++;
            } while (Math.Abs(firstTeamRanking - secondTeamRanking) > differenceBetweenSkillsInTeams);
            _secondTeam = b2;
            _firstTeam = a1;
        }
    }
}