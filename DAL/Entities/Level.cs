using Core;
using Core.Expansion.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Level : BaseEntity
    {
        public int GameTopicId {get; set;}
        public int LevelNumber { get; set; }
        public Difficulties Difficulties { get; set; }
        public virtual GameTopic GameTopic { get; set; }
    }
}
