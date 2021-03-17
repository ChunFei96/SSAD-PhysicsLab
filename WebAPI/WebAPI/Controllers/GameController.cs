using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using Services.Game;
using System.Text.Json;
using System.Net.Http;

namespace WebAPI.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        // Post: Game
        [HttpPost]
        [Route("save-game-score")]
        public IActionResult SaveGameScore(object gamescore)
        {
            try
            {
                if (gamescore == null)
                    return null;

                Dictionary<string, string> dict = JsonSerializer.Deserialize<Dictionary<string, string>>(gamescore.ToString());

                _gameService.SaveGameScore(dict["username"], dict["topicname"], dict["levelnumber"], Convert.ToInt32(dict["score"]), Convert.ToInt32(dict["timecompleted"]));
            }
            catch (Exception e)
            {
                return NotFound();

            }

            return Ok();
        }
    }
}
