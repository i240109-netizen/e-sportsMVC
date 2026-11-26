using AspNetCoreGeneratedDocument;

namespace e_sportsMVC.Models
{
    public class TournamentModel
    {
        public enum enumState
        {
            NotStarted,
            InProgress,
            Finished
        }

        private int m_Id;
        private int m_ChampionShipId;
        private string m_Name;
        private string m_Game;
        private enumState m_State;
        private List<TeamModel> m_Teams;
        private List<MatchModel> m_Matches;

        public int ID
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public int ChampionShipId
        {
            get { return m_ChampionShipId; }
            set { m_ChampionShipId = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public string Game
        {
            get { return m_Game; }
            set { m_Game = value; }
        }

        public enumState State
        {
            get { return m_State; }
            set { m_State = value; }
        }

        public List<TeamModel> Teams
        {
            get { return m_Teams; }
            set { m_Teams = value; }
        }

        public List<MatchModel> Matches
        {
            get { return m_Matches; }
            set { m_Matches = value; }
        }

        public TournamentModel()
        { }

        public TournamentModel(int id, int championshipId, string name, string game, enumState state, List<TeamModel> teams, List<MatchModel> matches)
        {
            ID = id;
            ChampionShipId = championshipId;
            Name = name;
            Game = game;
            State = state;
            Teams = teams;
            Matches = matches;
        }
    }
}
