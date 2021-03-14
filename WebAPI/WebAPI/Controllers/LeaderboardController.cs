using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using Services.Leaderboard;
using Core.Expansion.Enum;
using Core.Domain.Leaderboard;
using System.Text.Json;

namespace WebAPI.Controllers
{
    [Route("api/leaderboard")]
    [ApiController]
    public class LeaderboardController : Controller
    {
        private readonly ILeaderboardService _leaderboardService;

        public LeaderboardController(ILeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        // Post: Leaderboard
        [HttpPost]
        [Route("get-leaderboard-by-topic")]
        public IActionResult GetLeaderboardByTopic(object TopicName)
        {
            List<LeaderboardResultModel> resultModelList = new List<LeaderboardResultModel>();

            if (TopicName == null)
                return null;

            Dictionary<string, string> dict = JsonSerializer.Deserialize<Dictionary<string, string>>(TopicName.ToString());
            
            try
            {
                var resultList = _leaderboardService.GetLeaderboard((Core.Expansion.Enum.GameTopic)Enum.Parse(typeof(Core.Expansion.Enum.GameTopic), dict["TopicName"].ToString()));

                if (resultList != null && resultList.Count() > 0)
                {
                    foreach (var result in resultList)
                    {
                        if (result.Level != null)
                        {
                            LeaderboardResultModel resultModel = new LeaderboardResultModel();
                            resultModel.GameTopic = result.Level.GameTopic.GameTopicEnum.ToString();
                            resultModel.Student = result.Student.User.Name;
                            resultModel.LevelId = result.Level.LevelNumber;
                            resultModel.Score = result.Score;
                            resultModel.TimeCompleted = result.TimeCompleted;
                            resultModelList.Add(resultModel);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                return null;
            }
           
            return Json(resultModelList);
        }

        
    }
}
