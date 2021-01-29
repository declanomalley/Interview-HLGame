using HLGame.Interface;
using HLGame.Models;
using HLGame.Models.Game;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public HomeController(ILogger<HomeController> logger,IDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var NumberGenerator = new NumberGenerator_RandomNumbers_DifferFromPrevious();
            var NumberBoard = new HiLoNumbersBoard(NumberGenerator);
            var Game = new HiLoGuessGame(_dbContext, NumberBoard);

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
    }
}
