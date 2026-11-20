using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace e_sportsMVC.Models
{
    public static class DataBaseModel
    {
        private static List<UserModel> m_Users = new List<UserModel>();
        private static List<ChampionShipModel> m_ChampionShips = new List<ChampionShipModel>();
        private static List<TourmentModel> m_Tourments = new List<TourmentModel>();
        private static List<TeamModel> m_Teams = new List<TeamModel>();
        private static List<PlayerModel> m_Players = new List<PlayerModel>();
        //  private static List<MatchModel> m_Matchs = new List<MatchModel>();
        private static List<MatchModel> m_Matchs = new List<MatchModel>()
{
    new MatchModel
    {
        ID = "1",
        TourmentId = "T001",
        Date = DateTime.Now.AddDays(-1),
        TeamAId = "Team Alpha",
        TeamBId = "Team Beta",
        ResultA = "2",
        ResultB = "1",
        State = MatchModel.enumState.Finished
    },
    new MatchModel
    {
        ID = "2",
        TourmentId = "T001",
        Date = DateTime.Now.AddHours(2),
        TeamAId = "Team Gamma",
        TeamBId = "Team Delta",
        ResultA = "0",
        ResultB = "0",
        State = MatchModel.enumState.InProgress
    },
    new MatchModel
    {
        ID = "3",
        TourmentId = "T002",
        Date = DateTime.Now.AddDays(3),
        TeamAId = "Team Omega",
        TeamBId = "Team Zeta",
        ResultA = "",
        ResultB = "",
        State = MatchModel.enumState.NotStarted
    }
};


        public static List<int> UsersIDs
        {             
            get { return m_UsersIDs; }
            set { m_UsersIDs = value; }
        }
        public static List<int> ChampionShipsIDs
        {             
            get { return m_ChampionShipsIDs; }
            set { m_ChampionShipsIDs = value; }
        }
        public static List<int> MatchsIDs
        {
            get { return m_MatchsIDs; }
            set { m_MatchsIDs = value; }
        }
        public static List<int> PlayersIDs
        {
            get { return m_PlayersIDs; }
            set { m_PlayersIDs = value; }
        }
        public static List<int> TeamsIDs
        {
            get { return m_TeamsIDs; }
            set { m_TeamsIDs = value; }
        }
        public static List<int> TournamentsIDs
        {
            get { return m_TournamentsIDs; }
            set { m_TournamentsIDs = value; }
        }



        public static List<UserModel> Users
        {
            get { return m_Users; }
            set { m_Users = value; }
        }

        public static List<ChampionShipModel> ChampionShips
        {
            get { return m_ChampionShips; }
            set { m_ChampionShips = value; }
        }

        public static void SetStartData()
        {
            Users = new List<UserModel>()
            {
                new UserModel(1, "Admin", "Admin@gmail.com", UserModel.enumRole.Admin),
                new UserModel(2, "Captain", "Captain@gmail.com", UserModel.enumRole.Captain),
                new UserModel(3, "User", "User@gmail.com", UserModel.enumRole.User)
            };
            ChampionShips = new List<ChampionShipModel>()
            { 
                new ChampionShipModel(1, "EASports", "2026", new List<TournamentModel>
                {
                    new TournamentModel(1, 1, "Tournament 1", "GTA VI", TournamentModel.enumState.InProgress, new List<TeamModel>
                    {
                        new TeamModel(1, 1, "Team A", "Moon", new List<PlayerModel>
                        {
                            new PlayerModel(1, 1, "Dude", "BestPlayerAlive2009", 17, new List<int>{50, 50}),
                            new PlayerModel(2, 1, "SecondDude", "AlmostBestPlayerAlive2010", 16, new List<int>{50, 50})
                        }),
                        new TeamModel(2, 3, "Team A", "Moon", new List<PlayerModel>
                        {
                            new PlayerModel(3, 2, "JustName", "JustPlayer", 20, new List<int>{12, 88}),
                            new PlayerModel(4, 2, "Who", "Who's There?", 23, new List<int>{23, 11})
                        })
                    }, new List<MatchModel>
                    {
                        new MatchModel(1, 1, DateTime.Now, 1, 2, true, false, MatchModel.enumState.Finished),
                        new MatchModel(2, 1, DateTime.Now, 1, 2, false, false, MatchModel.enumState.InProgress)
                    }),
                })
            };
        }

        public static void ExportDataJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(ChampionShips, options);

            File.WriteAllText("export.json", jsonString);
            Console.WriteLine(Path.GetFullPath("export.json"));
        }

        public static void ExportDataXML()
        {

        }
    }
}
