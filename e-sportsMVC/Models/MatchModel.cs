namespace e_sportsMVC.Models
{
    public class MatchModel
    {
        public enum enumState
        {
            NotStarted,
            InProgress,
            Finished
        }

        private string m_ID;
        private string m_TournamentID;
        private DateTime m_Date;
        private string m_TeamAID;
        private string m_TeamBID;
        private int m_ResultA;
        private int m_ResultB; 
        public enumState State { get; set; }


        public string ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        public string TournamentID
        {
            get { return m_TournamentID; }
            set { m_TournamentID = value; }
        }

        public DateTime Date
        {
            get { return m_Date; }
            set { m_Date = value; }
        }

        public string TeamAID
        {
            get { return m_TeamAID; }
            set { m_TeamAID = value; }
        }

        public string TeamBID
        {
            get { return m_TeamBID; }
            set { m_TeamBID = value; }
        }

        public int ResultA
        {
            get { return m_ResultA; }
            set { m_ResultA = value; }
        }

        public int ResultB
        {
            get { return m_ResultB; }
            set { m_ResultB = value; }
        }
      
        public MatchModel()
        { }
    }
}
