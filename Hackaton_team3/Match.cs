using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton_team3
{
    public class Match
    {
        private Participant _participantOne;
        private Participant _participantTwo;
        private Status _status;
        private string _result;
        
        public Participant ParticipantOne
        {
            get { return _participantOne; }
            set { _participantOne = value; }
        }
       
        public Participant ParticipantTwo
        {
            get { return _participantTwo; }
            set { _participantTwo = value; }
        }
      
        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }
      
        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }
       
        public Match(Participant participant1, Participant participant2)
        {
            _participantOne = ParticipantOne = participant1;
            _participantTwo = ParticipantTwo = participant2;
            _status = Status.NotStarted;
            _result = "0:0";
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Match)
            {
                Match temp = (Match)obj;
                if (_participantOne.Equals(temp._participantOne) &&
                    _participantTwo.Equals(temp._participantTwo)
                    && _result.Equals(temp._result) && _status == temp._status)
                {
                    result = true;
                }
            }
           return result;
        }

    }
}