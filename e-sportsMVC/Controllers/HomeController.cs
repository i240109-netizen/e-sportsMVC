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
            var firstChamp = DataBaseModel.ChampionShips?.FirstOrDefault();
            var firstTournament = firstChamp?.Tournaments?.FirstOrDefault();
            var matches = firstTournament?.Matches ?? new List<MatchModel>();

            return View(matches);
        }

        public IActionResult Players()
        {
            var firstChamp = DataBaseModel.ChampionShips?.FirstOrDefault();
            var firstTournament = firstChamp?.Tournaments?.FirstOrDefault();
            var firstTeam = firstTournament?.Teams?.FirstOrDefault();
            var players = firstTeam?.Players ?? new List<PlayerModel>();

            return View(players);
        }

        public IActionResult Teams()
        {
            var firstChamp = DataBaseModel.ChampionShips?.FirstOrDefault();
            var firstTournament = firstChamp?.Tournaments?.FirstOrDefault();
            var teams = firstTournament?.Teams ?? new List<TeamModel>();

            return View(teams);
        }

        public IActionResult Tournaments()
        {
            var firstChamp = DataBaseModel.ChampionShips?.FirstOrDefault();
            var tournaments = firstChamp?.Tournaments ?? new List<TournamentModel>();

            return View(tournaments);
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
                var targetChamp = DataBaseModel.ChampionShips.FirstOrDefault(c => c.ID == tournament.ChampionShipId)
                                  ?? DataBaseModel.ChampionShips.FirstOrDefault();

                if (targetChamp != null)
                {
                    targetChamp.Tournaments ??= new List<TournamentModel>();
                    targetChamp.Tournaments.Add(tournament);
                }
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
                var targetTournament = AllTournaments().FirstOrDefault();
                if (targetTournament != null)
                {
                    targetTournament.Teams ??= new List<TeamModel>();
                    targetTournament.Teams.Add(team);
                }
                return RedirectToAction("Teams");
            }

            return View("Teams", DataBaseModel.ChampionShips);
        }

        [HttpPost]
        public IActionResult CreatePlayer(PlayerModel player)
        {
            if (ModelState.IsValid)
            {
                var targetTeam = AllTeams().FirstOrDefault();
                if (targetTeam != null)
                {
                    targetTeam.Players ??= new List<PlayerModel>();
                    targetTeam.Players.Add(player);
                }
                return RedirectToAction("Players");
            }

            return View("Players", DataBaseModel.ChampionShips);
        }

        [HttpPost]
        public IActionResult CreateMatch(MatchModel match)
        {
            if (ModelState.IsValid)
            {
                var targetTournament = AllTournaments().FirstOrDefault();
                if (targetTournament != null)
                {
                    targetTournament.Matches ??= new List<MatchModel>();
                    targetTournament.Matches.Add(match);
                }
                return RedirectToAction("Matches");
            }

            return View("Matches", DataBaseModel.ChampionShips);
        }

        // ================= HELPERS (procuram em todos os campeonatos) =================

        private static IEnumerable<TournamentModel> AllTournaments() =>
            DataBaseModel.ChampionShips.SelectMany(c => c.Tournaments ?? new List<TournamentModel>());

        private static IEnumerable<TeamModel> AllTeams() =>
            AllTournaments().SelectMany(t => t.Teams ?? new List<TeamModel>());

        // ================= CHAMPIONSHIPS: DELETE / EDIT =================

        [HttpPost]
        public IActionResult DeleteChampionShip(int id)
        {
            var item = DataBaseModel.ChampionShips.FirstOrDefault(c => c.ID == id);
            if (item != null) DataBaseModel.ChampionShips.Remove(item);
            return RedirectToAction("ChampionShips");
        }

        [HttpGet]
        public IActionResult EditChampionShip(int id)
        {
            var item = DataBaseModel.ChampionShips.FirstOrDefault(c => c.ID == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult EditChampionShip(int id, string name, string? year)
        {
            var item = DataBaseModel.ChampionShips.FirstOrDefault(c => c.ID == id);
            if (item == null) return NotFound();
            item.Name = name;
            item.Year = year;
            return RedirectToAction("ChampionShips");
        }

        // ================= TOURNAMENTS: DELETE / EDIT =================

        [HttpPost]
        public IActionResult DeleteTournament(int id)
        {
            foreach (var c in DataBaseModel.ChampionShips)
            {
                var item = c.Tournaments?.FirstOrDefault(t => t.ID == id);
                if (item != null) { c.Tournaments!.Remove(item); break; }
            }
            return RedirectToAction("Tournaments");
        }

        [HttpGet]
        public IActionResult EditTournament(int id)
        {
            var item = AllTournaments().FirstOrDefault(t => t.ID == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult EditTournament(int id, int championShipId, string name, string game, TournamentModel.enumState state)
        {
            var item = AllTournaments().FirstOrDefault(t => t.ID == id);
            if (item == null) return NotFound();
            item.ChampionShipId = championShipId;
            item.Name = name;
            item.Game = game;
            item.State = state;
            return RedirectToAction("Tournaments");
        }

        // ================= TEAMS: DELETE / EDIT =================

        [HttpPost]
        public IActionResult DeleteTeam(int id)
        {
            foreach (var t in AllTournaments())
            {
                var item = t.Teams?.FirstOrDefault(x => x.ID == id);
                if (item != null) { t.Teams!.Remove(item); break; }
            }
            return RedirectToAction("Teams");
        }

        [HttpGet]
        public IActionResult EditTeam(int id)
        {
            var item = AllTeams().FirstOrDefault(t => t.ID == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult EditTeam(int id, int captainId, string name, string country)
        {
            var item = AllTeams().FirstOrDefault(t => t.ID == id);
            if (item == null) return NotFound();
            item.CaptainId = captainId;
            item.Name = name;
            item.Country = country;
            return RedirectToAction("Teams");
        }

        // ================= PLAYERS: DELETE / EDIT =================

        [HttpPost]
        public IActionResult DeletePlayer(int id)
        {
            foreach (var team in AllTeams())
            {
                var item = team.Players?.FirstOrDefault(p => p.ID == id);
                if (item != null) { team.Players!.Remove(item); break; }
            }
            return RedirectToAction("Players");
        }

        [HttpGet]
        public IActionResult EditPlayer(int id)
        {
            var item = AllTeams().SelectMany(t => t.Players ?? new List<PlayerModel>()).FirstOrDefault(p => p.ID == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult EditPlayer(int id, int teamId, string name, string nickName, int age)
        {
            var item = AllTeams().SelectMany(t => t.Players ?? new List<PlayerModel>()).FirstOrDefault(p => p.ID == id);
            if (item == null) return NotFound();
            item.TeamID = teamId;
            item.Name = name;
            item.NickName = nickName;
            item.Age = age;
            return RedirectToAction("Players");
        }

        // ================= MATCHES: DELETE / EDIT =================

        [HttpPost]
        public IActionResult DeleteMatch(string id)
        {
            foreach (var t in AllTournaments())
            {
                var item = t.Matches?.FirstOrDefault(m => m.ID == id);
                if (item != null) { t.Matches!.Remove(item); break; }
            }
            return RedirectToAction("Matches");
        }

        [HttpGet]
        public IActionResult EditMatch(string id)
        {
            var item = AllTournaments().SelectMany(t => t.Matches ?? new List<MatchModel>()).FirstOrDefault(m => m.ID == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult EditMatch(string id, string tournamentID, DateTime date, string teamAID, string teamBID, int resultA, int resultB, MatchModel.enumState state)
        {
            var item = AllTournaments().SelectMany(t => t.Matches ?? new List<MatchModel>()).FirstOrDefault(m => m.ID == id);
            if (item == null) return NotFound();
            item.TournamentID = tournamentID;
            item.Date = date;
            item.TeamAID = teamAID;
            item.TeamBID = teamBID;
            item.ResultA = resultA;
            item.ResultB = resultB;
            item.State = state;
            return RedirectToAction("Matches");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}