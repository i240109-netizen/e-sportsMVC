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
            return View();
        }

        public IActionResult Matches()
        {
            return View();
        }

        public IActionResult Players()
        {
            return View(DataBaseModel.Players);
        }

        public IActionResult Teams()
        {
            return View();
        }

        public IActionResult Tourments()
        {
            return View();
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
