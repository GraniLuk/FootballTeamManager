﻿using FootballTeamManager.Skills.Infrastucture;
using System;
using System.Threading.Tasks;

namespace FootballTeamManager.Skills
{
    public class GetSkillService
    {
        private const int MinimumMatchesToBeRanked = 5;
        private const int MaximumMatchesToRanking = 10;
        private readonly IPlayersTeamRepository _playersTeamRespository;
        private readonly IFixturesRepository _fixturesRespository;
        public GetSkillService()
        {
            _playersTeamRespository = new PlayersTeamRepository();
            _fixturesRespository = new FixturesRepository();
        }   
        public async Task<int> GetSkill(int playerId)
        {
            var allPlayerTeams = _playersTeamRespository.GetAllTeamsForPlayer(playerId);
            if (allPlayerTeams.Count < MinimumMatchesToBeRanked) return 0;
            var skill = 0;
            var maximumMatches = Math.Min(MaximumMatchesToRanking, allPlayerTeams.Count);
            for (int i = 0; i < maximumMatches; i++)
            {
                var match = allPlayerTeams[i];
                if (match == null) break;
                var fixture = _fixturesRespository.GetForATeam(match.Team.Id);
                if (fixture != null)
                {
                    if (fixture.FirstTeamScore > fixture.SecondTeamScore)
                        skill++;
                }
                else
                {
                    fixture = _fixturesRespository.GetForBTeam(match.Team.Id);
                    if (fixture.SecondTeamScore > fixture.FirstTeamScore)
                    {
                        skill++;
                    }
                }
            }
            return skill; 
        }
    }
}