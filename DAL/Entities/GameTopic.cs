using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class GameTopic : BaseEntity
    {
        public int LevelId { get; set; }
        public GameTopic Type { get; set; }
    }
}
