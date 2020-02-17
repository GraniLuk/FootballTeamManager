using FootballManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballManager.Models
{
    public class Draw
    {
        private List<Player> _secondTeam;
        private List<Player> _firstTeam;
        private readonly ApplicationDbContext _context;



        public Draw(ApplicationDbContext context)
        {
            _context = context;
            GetExistingSquad();
        }

        public static IEnumerable<TeamPlayerAssociation> SetPlayersFromDraw(Team team, IEnumerable<Player> players)
        {
            return players.Select(x => new TeamPlayerAssociation() { Team = team, Player = x });
        }

        public void ResetTeam()
        {
            try
            {
                var players = _context.Players.Where(x => x.TeamNumber > 0);

                foreach (var player in players)
                {
                    player.TeamNumber = 0;
                    _context.Entry(player).State = EntityState.Modified;
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                var a = ex.Message;
                throw;
            }

        }

        public void DrawTeams()
        {
            var IsAnyTeam = _context.Players.Any(x => x.TeamNumber > 0);
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
                    var player = _context.Players.Find(item.Id);
                    player.TeamNumber = 1;
                    _context.Entry(player).State = EntityState.Modified;
                }
                _context.SaveChanges();

            }
            if (_secondTeam.Count > 0)
            {

                foreach (var item in _secondTeam)
                {
                    var player = _context.Players.Find(item.Id);
                    player.TeamNumber = 2;
                    _context.Entry(player).State = EntityState.Modified;
                }
                _context.SaveChanges();

            }

        }

        private void GetExistingSquad()
        {
            short counter;
            _firstTeam = _context.Players.Where(x => x.TeamNumber == 1 && x.Active).ToList();
            counter = 1;
            foreach (var item in _firstTeam)
            {
                item.Lp = counter;
                item.TeamNumber = 1;
                counter += 1;
            }
            _secondTeam = _context.Players.Where(x => x.TeamNumber == 2 && x.Active).ToList();
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
                var zespol = _context.Players.Where(x => x.Active).OrderBy(a => Guid.NewGuid()).ToList();
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

        public string GetNumberOfPlayer()
        {
            return (_firstTeam.Count + _secondTeam.Count).ToString();
        }

        public string GetPlayerFromFirstTeam(int id)
        {
            var result = "";

            foreach (var item in _firstTeam.Where(x => x.Lp == id).Select(z => z.ShortName))
            {
                result = item;
            }
            return result;
        }

        public string GetPlayerFromSecondTeam(int id)
        {
            string result = "";

            foreach (var item in _secondTeam.Where(x => x.Lp == id).Select(z => z.ShortName))
            {
                result = item;
            }

            return result;
        }
    }
}