using Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.User
{
    public interface IUserService
    {
        bool ValidateLogin(string username, string password);
        bool RegisterStudent(string username);
        void UpdateStudentCharacter(string username, string character);
        List<string> GetStudentList();
        StudentProfileModel GetStudentProfile(string username);
    }
}
