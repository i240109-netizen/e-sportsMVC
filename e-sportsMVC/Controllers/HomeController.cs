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
            if (DataBaseModel.ChampionShips.Count > 0)
                return View(DataBaseModel.ChampionShips);
            else
                return View();
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
            DataBaseModel.StartData();
            return View(DataBaseModel.ChampionShips[0].Tournaments[0].Teams);
        }

        public IActionResult Tournaments()
        {
            DataBaseModel.StartData();
            return View(DataBaseModel.ChampionShips[0].Tournaments);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateChampionShip()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateChampionShip(ChampionShipModel championship)
        {
            if(ModelState.IsValid)
            {
                DataBaseModel.ChampionShips.Add(championship);
                return RedirectToAction("ChampionShips");
            }

            return View(championship);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
