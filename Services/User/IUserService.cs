using Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.User
{
    public interface IUserService
    {
        //bool ValidateLogin(string username, string password);
        List<string> ValidateLogin(string username, string password);
        bool RegisterStudent(string username);
        bool UpdateStudentCharacter(string username, string character);
        List<string> GetStudentList();
        List<string> GetValidStudentList();
        StudentProfileModel GetStudentProfile(string username, bool byEmail);
    }
}
