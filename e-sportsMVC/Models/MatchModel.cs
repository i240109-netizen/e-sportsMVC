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

        private string m_Id;
        private string m_TourmentId;
        private DateTime m_Date;
        private string m_TeamAId;
        private string m_TeamBId;
        private string m_ResultA;
        private string m_ResultB; 
        public enumState State { get; set; }


        public int ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        public int TournamentID
        {
            get { return m_TournamentID; }
            set { m_TournamentID = value; }
        }

        public DateTime Date
        {
            get { return m_Date; }
            set { m_Date = value; }
        }

        public int TeamAID
        {
            get { return m_TeamAID; }
            set { m_TeamAID = value; }
        }

        public int TeamBID
        {
            get { return m_TeamBID; }
            set { m_TeamBID = value; }
        }

        public bool ResultA
        {
            get { return m_ResultA; }
            set { m_ResultA = value; }
        }

        public bool ResultB
        {
            get { return m_ResultB; }
            set { m_ResultB = value; }
        }
      
    }
}
