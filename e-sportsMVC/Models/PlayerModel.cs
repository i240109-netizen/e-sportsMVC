namespace e_sportsMVC.Models
{
    public class PlayerModel
    {
        private string m_Id;
        private string m_TeamId;
        private string m_Name;
        private string m_NickName;
        private int m_Age;
        private List<int> m_Points;
        
        public string ID
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public string TeamID
        {
            get { return m_TeamId; }
            set { m_TeamId = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
    
        public string NickName
        {
            get { return m_NickName; }
            set { m_NickName = value; }
        }

        public int Age
        {
            get { return m_Age; }
            set { m_Age = value; }
        }

        public List<int> Points
        {
            get { return m_Points; }
            set { m_Points = value; }
        }
    }
}
