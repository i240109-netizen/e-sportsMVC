namespace e_sportsMVC.Models
{
    public static class DataBaseModel
    {
        private static List<UserModel> m_Users = new List<UserModel>();
        private static List<ChampionShipModel> m_ChampionShips = new List<ChampionShipModel>();
        private static List<TourmentModel> m_Tourments = new List<TourmentModel>();
        private static List<TeamModel> m_Teams = new List<TeamModel>();
        private static List<PlayerModel> m_Players = new List<PlayerModel>();
        private static List<MatchModel> m_Matchs = new List<MatchModel>();


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

        public static List<TourmentModel> Tourments
        {
            get { return m_Tourments; }
            set { m_Tourments = value; }
        }

        public static List<PlayerModel> Players
                    {
            get { return m_Players; }
            set { m_Players = value; }
        }
        public static List<TeamModel> Teams
        {
            get { return m_Teams; }
            set { m_Teams = value; }
        }

        public static List<MatchModel> Matchs 
        {
            get { return m_Matchs; }
            set { m_Matchs = value; }
        }

        public static void SetStartData()
        {
            m_Users = new List<UserModel>();
            m_ChampionShips = new List<ChampionShipModel>();
            m_Tourments = new List<TourmentModel>();
            m_Teams = new List<TeamModel>();
            m_Players = new List<PlayerModel>();
            m_Matchs = new List<MatchModel>();
        }
    }
}
