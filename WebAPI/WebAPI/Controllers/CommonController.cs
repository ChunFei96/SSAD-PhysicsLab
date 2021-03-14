using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using Services.Common;
using System.Text.Json;

namespace WebAPI.Controllers
{
    [Route("api/common")]
    [ApiController]
    public class CommonController : Controller
    {
        private readonly ICommonService _commonService;
        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpPost]
        [Route("get-enum-by-type")]
        public IActionResult GetEnumbyType(object enumType)
        {
            List<string> enumList = new List<string>();
            try
            {
                if (enumType == null)
                    return null;

                Dictionary<string, string> dict = JsonSerializer.Deserialize<Dictionary<string, string>>(enumType.ToString());

                enumList = _commonService.GetEnumbyType(dict["enumType"]);
            }
            catch (Exception e)
            {
                return null;
            }
            return Json(enumList);
        }
    }
}
