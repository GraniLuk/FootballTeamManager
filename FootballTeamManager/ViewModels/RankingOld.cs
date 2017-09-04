using FootballTeamManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballTeamManager.ViewModels
{
    public class RankingOld
    {
        public RankingOld(List<Player> players)
        {
            RankingList = GetResults(players);
        }

        public IEnumerable<Result> RankingList { get; set; }

        static IEnumerable<Result> GetResults(List<Player> players)
        {
            int r = 1;
            double lastSkill = -1;
            int lastRank = 1;

            foreach (var rank in from name in players
                                 let skill = name.Skill
                                 orderby skill descending
                                 select new Result { PlayerName = name.Name, PlayerId = name.Id, Rank = r++, Skill = skill })
            {
                if (lastSkill == rank.Skill)
                {
                    rank.Rank = lastRank;
                }
                lastSkill = rank.Skill;
                lastRank = rank.Rank;
                yield return rank;
            }
        }
    }

    public class Result
    {
        public string PlayerName;
        public int PlayerId { get; set; }
        public int Skill;
        public int Rank;
    }
}