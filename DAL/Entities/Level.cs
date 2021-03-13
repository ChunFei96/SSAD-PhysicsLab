using Core;
using Core.Expansion.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Level : BaseEntity
    {
        public Difficulties Difficulties { get; set; }
    }
}
