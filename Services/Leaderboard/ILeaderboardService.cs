using DAL.Entities;
using System.Collections.Generic;

namespace Services.Leaderboard
{
    public interface ILeaderboardService
    {
        public List<DAL.Entities.Leaderboard> GetLeaderboard();
    }
}
