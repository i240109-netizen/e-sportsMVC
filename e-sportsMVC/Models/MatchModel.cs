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

        private int m_ID;
        private int m_TournamentID;
        private DateTime m_Date;
        private int m_TeamAID;
        private int m_TeamBID;
        private bool m_ResultA;
        private bool m_ResultB;
        private enumState m_State;


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

        public enumState State
        {
            get { return m_State; }
            set { m_State = value; }
        }

        public MatchModel(int id, int tournamentId, DateTime date, int teamAId, int teamBId, bool resultA, bool resultB, enumState state)
        {
            ID = id;
            TournamentID = tournamentId;
            Date = date;
            TeamAID = teamAId;
            TeamBID = teamBId;
            ResultA = resultA;
            ResultB = resultB;
            State = state;
            DataBaseModel.MatchsIDs.Add(ID);
        }
    }
}
