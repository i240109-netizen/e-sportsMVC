namespace e_sportsMVC.Models
{
    public class UserModel
    {
        private enum enumRole
        {
            User,
            Captain,
            Admin
        }

        private string m_Id;
        private string m_FullName;
        private string m_Email;
        private enumRole m_Role;

        public string ID
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
    }
}
