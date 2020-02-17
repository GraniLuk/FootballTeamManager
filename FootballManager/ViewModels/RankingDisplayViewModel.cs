using FootballManager.Models;

namespace FootballManager.ViewModels
{
    public class RankingDisplayViewModel
    {
        public Ranking PlayerRanking { get; set; }
        public Player Player { get; set; }
        public string ChangeAmount => (-(PlayerRanking.Place - PlayerRanking.PlaceInPreviousWeek)).ToString();
        public Change Change => GetChange();

        private Change GetChange()
        {
            if (PlayerRanking.PlaceInPreviousWeek == 0)
                return Change.New;
            if (PlayerRanking.Place < PlayerRanking.PlaceInPreviousWeek)
                return Change.Increase;
            return PlayerRanking.Place > PlayerRanking.PlaceInPreviousWeek ? Change.Fall : Change.Maintain;
        }
    }

    public enum Change
    {
        Increase, Fall, Maintain, New
    }
}