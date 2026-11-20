namespace e_sportsMVC.Models
{
    public class UserModel
    {
        public enum enumRole
        {
            User,
            Captain,
            Admin
        }

        private int m_Id;
        private string m_FullName;
        private string m_Email;
        private enumRole m_Role;

        public int ID
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public string FullName
        {
            get { return m_FullName; }
            set { m_FullName = value; }
        }

        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        public enumRole Role
        {
            get { return m_Role; }
            set { m_Role = value; }
        }

        public UserModel(int id, string fullName, string email, enumRole role)
        {
            ID = id;
            FullName = fullName;
            Email = email;
            Role = role;
        }
    }
}
