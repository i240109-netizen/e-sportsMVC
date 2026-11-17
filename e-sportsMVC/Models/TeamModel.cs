namespace e_sportsMVC.Models
{
    public class TeamModel
    {
        private string m_Id;
        private string m_CaptainId;
        private string m_Name;
        private string m_Country;
        private List<PlayerModel> m_Players;

        public string ID
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public string CaptainId
        {
            get { return m_CaptainId; }
            set { m_CaptainId = value; }
        }

        public string Name
        {   get { return m_Name; }
            set { m_Name = value; }
        }

        public string Country
        {
            get { return m_Country; }
            set { m_Country = value; }
        }

        public List<PlayerModel> Players
        {
            get { return m_Players; }
            set { m_Players = value; }
        }
    }
}
