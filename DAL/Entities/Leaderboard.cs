using Core;
using Core.Expansion.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Leaderboard : BaseEntity
    {
        public int TopicId { get; set; }
        public GameType Type { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
