using System.ComponentModel.DataAnnotations;

namespace e_sportsMVC.Models
{
    public class PlayerModel
    {
        private int m_Id;
        private int m_TeamId;
        private string m_Name;
        private string m_NickName;
        private int m_Age;
        private List<int> m_Points;

        [Required]
        public int ID
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        [Required]
        public int TeamID
        {
            get { return m_TeamId; }
            set { m_TeamId = value; }
        }
        [Required]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        [Required]
        public string NickName
        {
            get { return m_NickName; }
            set { m_NickName = value; }
        }
        [Required]
        public int Age
        {
            get { return m_Age; }
            set { m_Age = value; }
        }
        [Required]
        public List<int> Points
        {
            get { return m_Points; }
            set { m_Points = value; }
        }

        public PlayerModel()
        { }

        public PlayerModel(int id, int teamid, string name, string nickname, int age, List<int> points)
        {
            ID = id;
            TeamID = teamid;
            Name = name;
            NickName = nickname;
            Age = age;
            Points = points;
        }
    }
}
