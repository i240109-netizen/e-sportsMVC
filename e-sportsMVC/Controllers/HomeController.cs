using System.Diagnostics;
using e_sportsMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_sportsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ChampionShips()
        {
            return View(DataBaseModel.ChampionShips);
        }

        public IActionResult Matches()
        {
            DataBaseModel.StartData();
            return View(DataBaseModel.ChampionShips[0].Tournaments[0].Matchs);
        }

        public IActionResult Players()
        {
            DataBaseModel.StartData();
            return View(DataBaseModel.ChampionShips[0].Tournaments[0].Teams[0].Players);
        }

        public IActionResult Teams()
        {
            return View(DataBaseModel.ChampionShips);
        }

        public IActionResult Tourments()
        {
            return View(DataBaseModel.ChampionShips);
        }

        public IActionResult Login()
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
