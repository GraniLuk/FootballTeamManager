using FootballTeamManager.Skills.Infrastucture;
using System.Threading.Tasks;

namespace FootballTeamManager.Skills
{
    public class GetSkillService
    {
        private const int MinimumMatchesToBeRanked = 5;
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
            foreach (var match in allPlayerTeams)
            {
                var fixture = await _fixturesRespository.GetForATeam(match.Team.Id).ConfigureAwait(false);
                if (fixture != null)
                {
                    if (fixture.FirstTeamScore > fixture.SecondTeamScore)
                        skill++;
                }
                else
                {
                    fixture = await _fixturesRespository.GetForBTeam(match.Team.Id);
                    if (fixture.SecondTeamScore> fixture.FirstTeamScore)
                    {
                        skill++;
                    }
                }
            }
            return skill; 
        }
    }
}