using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using Services.User;
using System.Text.Json;
using Core.Domain.User;

namespace WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("validate-login")]
        public IActionResult ValidateLogin(object loginCredential)
        {
            //bool isValidLogin = false;
            var isValidLogin = new List<string>() { "false"};
            try
            {
                if (loginCredential == null)
                    return null;

                Dictionary<string, string> dict = JsonSerializer.Deserialize<Dictionary<string, string>>(loginCredential.ToString());

                isValidLogin = _userService.ValidateLogin(dict["username"], dict["password"]);
            }
            catch(Exception e)
            {
                return null;
            }
            return Json(isValidLogin);
        }

        [HttpPost]
        [Route("register-student")]
        public IActionResult RegisterStudent(object studentName)
        {
            bool isValidLogin = false;
            try
            {
                if (studentName == null)
                    return null;

                Dictionary<string, string> dict = JsonSerializer.Deserialize<Dictionary<string, string>>(studentName.ToString());

                //_userService.RegisterStudent(dict["studentname"]);
                isValidLogin = _userService.RegisterStudent(dict["username"]);
            }
            catch (Exception e)
            {
                return null;
            }
            return Json(isValidLogin);
        }

        [HttpPost]
        [Route("update-student-character")]
        public IActionResult UpdateStudentCharacter(object studentModel)
        {
            bool successfulUpdate = false;
            try
            {
                if (studentModel == null)
                    return null;

                Dictionary<string, string> dict = JsonSerializer.Deserialize<Dictionary<string, string>>(studentModel.ToString());

                successfulUpdate = _userService.UpdateStudentCharacter(dict["username"], dict["character"]);
            }
            catch (Exception e)
            {
                return null;
            }
            return Json(successfulUpdate);
        }

        [HttpGet]
        [Route("get-student-for-registration")]
        public IActionResult GetStudentList()
        {
            List<string> studentsName = new List<string>();
            try
            {
                studentsName = _userService.GetStudentList();
            }
            catch (Exception e)
            {
                return null;
            }
            return Json(studentsName);
        }

        [HttpGet]
        [Route("get-valid-students")]
        public IActionResult GetValidStudentList()
        {
            List<string> studentsName = new List<string>();
            try
            {
                studentsName = _userService.GetValidStudentList();
            }
            catch (Exception e)
            {
                return null;
            }
            return Json(studentsName);
        }

        [HttpPost]
        [Route("get-student-profile")]
        public IActionResult GetStudentProfile(object username)
        {
            StudentProfileModel studentProfile = new StudentProfileModel();
            try
            {
                if (username == null)
                    return null;

                Dictionary<string, string> dict = JsonSerializer.Deserialize<Dictionary<string, string>>(username.ToString());

                var aa = Convert.ToBoolean(dict["byEmail"]);
                studentProfile = _userService.GetStudentProfile(dict["username"], aa);
            }
            catch (Exception e)
            {
                return null;
            }
            return Json(studentProfile);
        }

       
    }
}
