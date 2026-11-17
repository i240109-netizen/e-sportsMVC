namespace e_sportsMVC.Models
{
    public class ChampionShipModel
    {
        private string m_Id;
        private string m_name;
        private string m_Year;
        private List<TourmentModel> m_Tourments;

        public string ID
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

        public List<TourmentModel> Tourments
        {
            get { return m_Tourments; }
            set { m_Tourments = value; }
        }
    }
}
