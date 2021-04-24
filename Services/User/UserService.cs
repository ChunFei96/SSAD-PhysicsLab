using Core.Domain.User;
using Core.Expansion.Enum;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.User
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<string> ValidateLogin(string username, string password)
        {
            Users user =  _unitOfWork.UsersRepository.Get(u => u.Username.Equals(username) && u.Password.Equals(password)).FirstOrDefault();
            if (user != null)
            {

                var role = user.Role ;//(Role)Enum.Parse(typeof(Role), );
                var isTeacherRole = role.Equals(Role.Teacher);

                if (isTeacherRole)
                {
                    return new List<string>() { "true", "99" };  //Return 99 to indicate this is teacher
                }
                else
                {
                    var student = _unitOfWork.StudentsRepository.Get(u => u.UserId == user.Id).FirstOrDefault();
                    if (student != null && student.SelectedCharacter != null)
                    {
                        var selectedChar = student.SelectedCharacter.ToString();
                        return new List<string>() { "true", selectedChar };
                    }
                    return new List<string>() { "true", "-1" };  //Return -1 to indicate this player havent select any Character
                }

            }
            return new List<string>() { "false"};
        }

        public bool RegisterStudent(string name)
        {
            Users user = _unitOfWork.UsersRepository.Get(u => u.Name.Equals(name)).FirstOrDefault();
            if (user != null)
            {
                user.Password = "Test1234";
                _unitOfWork.UsersRepository.Update(user);
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public bool UpdateStudentCharacter(string username, string character)
        {
            Users user = _unitOfWork.UsersRepository.Get(u => u.Username.Equals(username)).FirstOrDefault();
            if(user != null)
            {
                Students student = _unitOfWork.StudentsRepository.Get(s => s.UserId.Equals(user.Id)).FirstOrDefault();
                if(student != null)
                {
                    student.SelectedCharacter = (GameCharacters)Enum.Parse(typeof(GameCharacters), character);
                    student.ModifiedTimeStamp = DateTime.Now;  //test
                    _unitOfWork.StudentsRepository.Update(student);


                    user.ModifiedTimeStamp = DateTime.Now; //test      

                    _unitOfWork.Commit();
                    return true;
                }
                return false;
            }
            return false;
        }

        public List<string> GetStudentList()
        {
            var students =  _unitOfWork.UsersRepository.Get(u => u.Password == null && u.Role == Role.Student).Select(x => x.Name).ToList();
            return students;
        }

        public List<string> GetValidStudentList()
        {
            var students = _unitOfWork.UsersRepository.Get(u => u.Status.Equals(Status.Active) && u.Role == Role.Student).Select(x => x.Name).ToList();
            return students;
        }

        public StudentProfileModel GetStudentProfile(string username, bool byEmail)
        {
            StudentProfileModel studentProfileModel = new StudentProfileModel();

            Users user;

            //byEmail : indicate the passing in argument want to filter the records by [Username]. Both Username or Name are use for different cases
            if (byEmail)
            {
               user = _unitOfWork.UsersRepository.Get(u => u.Username.Equals(username)).FirstOrDefault();
            }
            else
            {
               user = _unitOfWork.UsersRepository.Get(u => u.Name.Equals(username)).FirstOrDefault();
            }

            if(user != null)
            {
                Students student = _unitOfWork.StudentsRepository.Get(s => s.UserId.Equals(user.Id)).FirstOrDefault();
                if(student != null)
                {
                    studentProfileModel.StudentName = user.Name;
                    studentProfileModel.SelectedCharacter = student.SelectedCharacter.ToString();
                    studentProfileModel.Gender = user.Gender.ToString();
                    studentProfileModel.Age = user.Age;
                    studentProfileModel.Role = user.Role.ToString();
                }
            }

            return studentProfileModel;
        }
    }
}
