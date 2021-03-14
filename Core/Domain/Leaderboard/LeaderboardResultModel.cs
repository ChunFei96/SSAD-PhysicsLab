using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Leaderboard
{
    public class LeaderboardResultModel
    {
        public string GameTopic { get; set; }
        public string Student { get; set; }
        public int LevelId { get; set; }
        public int Score { get; set; }
        public int TimeCompleted { get; set; }
    }
}
