using System;

namespace Hackaton_team3
{
    public class Match : ISerializableToDB
    {
        private Participant _participantOne;
        private Participant _participantTwo;
        private string _result;
        public Participant ParticipantOne
        {
            get
            {
                return _participantOne;
            }
            set
            {
                if (value != null)
                {
                    _participantOne = value;
                }
                else
                {
                    throw new ArgumentNullException("Value is null");
                }
            }
        }
        public Participant ParticipantTwo
        {
            get
            {
                return _participantTwo;
            }
            set
            {
                if (value != null)
                {
                    _participantTwo = value;
                }
                else
                {
                    throw new ArgumentNullException("Value is null");
                }
            }
        }
        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                if (value != null)
                {
                    _result = value;
                }
                else
                {
                    throw new ArgumentNullException("Value is null");
                }
            }
        }
        public Status Status { get; set; }

        public Layers Layer { get; set; }
        public Match()
        {

        }

        private Match(Participant participantOne, Participant participantTwo)
        {
            ParticipantOne = participantOne;
            ParticipantTwo = participantTwo;
            Status = Status.NotStarted;
            _result = string.Empty;
        }

        public static Match Create(Participant participantOne, Participant participantTwo)
        {
            if (participantOne != null && participantTwo != null)
            {
                return new Match(participantOne, participantTwo);
            }
            else if (participantOne == null)
            {
                throw new ArgumentNullException("Participan one is null");
            }
            else
            {
                throw new ArgumentNullException("Participan two is null");
            }
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Match)
            {
                Match temp = (Match)obj;
                if (_participantOne.Equals(temp._participantOne)
                    && _participantTwo.Equals(temp._participantTwo)
                    && _result.Equals(temp._result)
                    && Status == temp.Status)
                {
                    result = true;
                }
            }

            return result;
        }

        public string Serialize()
        {
            throw new NotImplementedException();
        }
    }
}
