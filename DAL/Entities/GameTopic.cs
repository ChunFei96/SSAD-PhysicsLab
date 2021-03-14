using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class GameTopic : BaseEntity
    {
        public Core.Expansion.Enum.GameTopic GameTopicEnum { get; set; }
    }
}
