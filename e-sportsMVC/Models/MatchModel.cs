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

        private int m_MatchId;
        private DateTime m_Date;
        private int m_TeamAId;
        private int m_TeamBId;
        private bool m_ResultA;
        private bool m_ResultB;
        private enumState m_State;


        public int MatchId
        {
            get { return m_MatchId; }
            set { m_MatchId = value; }
        }

        public DateTime Date
        {
            get { return m_Date; }
            set { m_Date = value; }
        }

        public int TeamAId
        {
            get { return m_TeamAId; }
            set { m_TeamAId = value; }
        }

        public int TeamBId
        {
            get { return m_TeamBId; }
            set { m_TeamBId = value; }
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

        public enumState State
        {
            get { return m_State; }
            set { m_State = value; }
        }

        public MatchModel(int matchId, DateTime date, int teamAId, int teamBId, bool resultA, bool resultB, enumState state)
        {
            TourmentId = matchId;
            Date = date;
            TeamAId = teamAId;
            TeamBId = teamBId;
            ResultA = resultA;
            ResultB = resultB;
            State = state;
            DataBaseModel.MatchsIDs.Add(matchId);
        }
    }
}
