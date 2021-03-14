using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.User
{
    public class StudentProfileModel
    {
        public string StudentName { get; set; }
        public string SelectedCharacter { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
    }
}
