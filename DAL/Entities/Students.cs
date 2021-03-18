using Core;
using Core.Expansion.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Students : BaseEntity
    {
        public int UserId { get; set; }

        public GameCharacters? SelectedCharacter { get; set; }

        public virtual Users User { get; set; }
    }
}
