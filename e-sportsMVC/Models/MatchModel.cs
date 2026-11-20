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

        public string ID
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public string TourmentId
        {
            get { return m_TourmentId; }
            set { m_TourmentId = value; }
        }

        public DateTime Date
        {
            get { return m_Date; }
            set { m_Date = value; }
        }

        public string TeamAId
        {
            get { return m_TeamAId; }
            set { m_TeamAId = value; }
        }

        public string TeamBId
        {
            get { return m_TeamBId; }
            set { m_TeamBId = value; }
        }

        public string ResultA
        {
            get { return m_ResultA; }
            set { m_ResultA = value; }
        }

        public string ResultB
        {
            get { return m_ResultB; }
            set { m_ResultB = value; }
        }
      
    }
}
