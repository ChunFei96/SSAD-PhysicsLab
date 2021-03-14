using Core;
using Core.Expansion.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Leaderboard : BaseEntity
    {
        public int LevelId { get; set; }
        public int StudentId { get; set; }
        public int Score { get; set; }
        public int TimeCompleted { get; set; }
        public int TrialCount { get; set; }
        public virtual Level Level { get; set; }
        public virtual Students Student { get; set; }
    }
}
