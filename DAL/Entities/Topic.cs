using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Topic : BaseEntity
    {
        public int StudentId { get; set; }
        public int LevelId { get; set; }
        public int Score { get; set; }
        public int TimeCompleted { get; set; }
        public int TrialCount { get; set; }
        public virtual Students Student { get; set; }
    }
}
