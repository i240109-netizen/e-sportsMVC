using System.ComponentModel.DataAnnotations;

namespace e_sportsMVC.Models
{
    public class ChampionShipModel
    {
        private int m_Id;
        private string m_name;
        private string m_Year;
        private List<TournamentModel>? m_Tournaments;

        [Unique(typeof(ChampionShipModel))]
        public int ID
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public string Year
        {
            get { return m_Year; }
            set { m_Year = value; }
        }

        public List<TournamentModel>? Tournaments
        {
            get { return m_Tournaments; }
            set { m_Tournaments = value; }
        }

        public ChampionShipModel()
        { }

        public ChampionShipModel(int id, string name, string year, List<TournamentModel>? tournaments)
        {
            ID = id;
            Name = name;
            Year = year;
            Tournaments = tournaments;
        }
    }
}
