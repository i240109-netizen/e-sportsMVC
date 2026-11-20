using System.Text.Json;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace e_sportsMVC.Models
{
    public static class DataBaseModel
    {
        private static List<UserModel> m_Users = new List<UserModel>();
        private static List<ChampionShipModel> m_ChampionShips = new List<ChampionShipModel>();
        private static List<int> m_UsersIDs = new List<int>();
        private static List<int> m_ChampionShipsIDs = new List<int>();
        private static List<int> m_MatchsIDs = new List<int>();
        private static List<int> m_PlayersIDs = new List<int>();
        private static List<int> m_TeamsIDs = new List<int>();
        private static List<int> m_TournamentsIDs = new List<int>();


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
            string path = "export.xml";

            using (XmlWriter writer = XmlWriter.Create(path,
                new XmlWriterSettings { Indent = true }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("eSports");

                foreach (var championship in ChampionShips)
                {
                    writer.WriteStartElement("Championship");

                    writer.WriteElementString("ID", championship.ID.ToString());
                    writer.WriteElementString("Name", championship.Name);
                    writer.WriteElementString("Year", championship.Year.ToString());

                    foreach (var tournament in championship.Tournaments)
                    {
                        writer.WriteStartElement("Tournament");

                        writer.WriteElementString("ID", tournament.ID.ToString());
                        writer.WriteElementString("Name", tournament.Name);
                        writer.WriteElementString("Game", tournament.Game);

                        foreach (var teamID in tournament.Teams)
                        {
                            writer.WriteElementString("TeamID", teamID.ToString());
                        }

                        foreach (var match in tournament.Matchs)
                        {
                            writer.WriteStartElement("Match");

                            writer.WriteElementString("ID", match.MatchId.ToString());
                            writer.WriteElementString("Date", match.Date.ToString());
                            writer.WriteElementString("TeamAID", match.TeamAId.ToString());
                            writer.WriteElementString("TeamBID", match.TeamBId.ToString());
                            writer.WriteElementString("ResultA", match.ResultA.ToString());
                            writer.WriteElementString("ResultB", match.ResultB.ToString());
                            writer.WriteElementString("State", match.State.ToString());

                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement(); // Tournament
                    }

                    writer.WriteEndElement(); // Championship
                }

                writer.WriteEndElement(); // eSports
                writer.WriteEndDocument();
            }

            Console.WriteLine(Path.GetFullPath(path));
        }
    }
}
