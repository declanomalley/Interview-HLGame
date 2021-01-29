using HLGame.Interface;
using HLGame.Models;
using HLGame.Models.Game;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HLGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDBContext _dbContext;
        private const string gameData = "gameData";

        public HomeController(ILogger<HomeController> logger, IDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            HiLoGuessGame Game = null;

            Game = GetGameFromSession();
            if (Game == null)
            {
                var NumberGenerator = new NumberGenerator_RandomNumbers_DifferFromPrevious();
                var NumberBoard = new HiLoNumbersBoard(NumberGenerator);
                Game = new HiLoGuessGame(_dbContext, NumberBoard);
            }

            // dont want to pass model to page as it will reveleal the numbers
            SaveGameToSession(Game);


            return View(Game);
        }

        [HttpPost]
        public IActionResult Index(HiLoGuessGame Game)
        {
            Game = GetGameFromSession();
            Game.Guess(true);
            SaveGameToSession(Game);

            return View(Game);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private HiLoGuessGame GetGameFromSession()
        {
            var value = HttpContext.Session.GetString(gameData);
            if (value != null)
                return JsonConvert.DeserializeObject<HiLoGuessGame>(value, new JsonSerializerSettings() { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto });

            return null;
        }

        private bool SaveGameToSession(HiLoGuessGame Game) {
            var serialisedDate = JsonConvert.SerializeObject(Game, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
            HttpContext.Session.SetString(gameData, serialisedDate);
            return true;
        }
    }
}
