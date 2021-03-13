using Core;
using Core.Expansion.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Users : BaseEntity
    {
        public Role Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public  Gender? Gender { get; set; }
        public int Age { get; set; }
    }
}
