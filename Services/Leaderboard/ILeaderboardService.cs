using Core.Expansion.Enum;
using DAL.Entities;
using System.Collections.Generic;

namespace Services.Leaderboard
{
    public interface ILeaderboardService
    {
        public List<DAL.Entities.Leaderboard> GetLeaderboard(GameType TopicId);
    }
}
