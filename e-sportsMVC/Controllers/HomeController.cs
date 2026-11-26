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

        public IActionResult Index() => View();
        public IActionResult Privacy() => View();
        public IActionResult ChampionShips() => View();

        public IActionResult Matches()
        {
            return View(DataBaseModel.ChampionShips[0].Tournaments[0].Matches);
        }

        public IActionResult Players()
        {
            return View(DataBaseModel.ChampionShips[0].Tournaments[0].Teams[0].Players);
        }

        public IActionResult Teams()
        {
            return View(DataBaseModel.ChampionShips[0].Tournaments[0].Teams);
        }

        public IActionResult Tournaments()
        {
            return View(DataBaseModel.ChampionShips[0].Tournaments);
        }

        public IActionResult TournamentsTable(int championshipId)
        {
            var championship = DataBaseModel.ChampionShips
                .FirstOrDefault(c => c.ID == championshipId);

            var tournaments = championship?.Tournaments ?? new List<TournamentModel>();
            return PartialView("_TournamentsTable", tournaments);
        }


        public IActionResult Login() => RedirectToAction("Login", "Account");


        [HttpPost]
        public IActionResult CreateChampionShip(ChampionShipModel championship)
        {
            if (ModelState.IsValid)
            {
                championship.Tournaments ??= new List<TournamentModel>();
                DataBaseModel.ChampionShips.Add(championship);
                return RedirectToAction("ChampionShips");
            }

            return View("ChampionShips", DataBaseModel.ChampionShips);
        }


        [HttpPost]
        public IActionResult CreateTournament(TournamentModel tournament)
        {
            if (ModelState.IsValid)
            {
                tournament.Matches ??= new List<MatchModel>();
                DataBaseModel.ChampionShips[0].Tournaments.Add(tournament);
                return RedirectToAction("Tournaments");
            }

            return View("Tournaments", DataBaseModel.ChampionShips);
        }


        [HttpPost]
        public IActionResult CreateTeam(TeamModel team)
        {
            if (ModelState.IsValid)
            {
                team.Players ??= new List<PlayerModel>();
                DataBaseModel.ChampionShips[0].Tournaments[0].Teams.Add(team);
                return RedirectToAction("Teams");
            }

            return View("Teams", DataBaseModel.ChampionShips);
        }


        [HttpPost]
        public IActionResult CreatePlayer(PlayerModel player)
        {
            if (ModelState.IsValid)
            {
                DataBaseModel.ChampionShips[0].Tournaments[0].Teams[0].Players.Add(player);
                return RedirectToAction("Players");
            }

            return View("Players", DataBaseModel.ChampionShips);
        }


        [HttpPost]
        public IActionResult CreateMatch(MatchModel match)
        {
            if (ModelState.IsValid)
            {
                DataBaseModel.ChampionShips[0].Tournaments[0].Matches.Add(match);
                return RedirectToAction("Matches");
            }

            return View("Matches", DataBaseModel.ChampionShips);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}