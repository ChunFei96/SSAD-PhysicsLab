using Core.Expansion.Enum;
using DAL.Entities;
using System.Collections.Generic;

namespace Services.Leaderboard
{
    public interface ILeaderboardService
    {
        public List<DAL.Entities.Leaderboard> GetLeaderboard(Core.Expansion.Enum.GameTopic TopicId);
        public List<DAL.Entities.Leaderboard> GetLeaderboard();
    }
}
