using System;
using System.Drawing;
using System.Text;

namespace Hackaton_team3
{
    public class Match
    {
        public string participantId1 { get; set; }
        public string participantId2 { get; set; }
        private Participant _participantOne;
        private Participant _participantTwo;
        private string _result = "";
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

        public int Id { get; set; }
        public Layers Layer { get; set; }
        public Point Location { get; set; }
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
        
        private Match (string line)
        {
            string[] parsed = line.Split(",".ToCharArray());
            Id = int.Parse(parsed[0]);
            //participantId1 = parsed[1];
            //participantId2 = parsed[2];
            Result = parsed[3];
            if (!Enum.TryParse(parsed[4], out Status status))
            {
                status = Status.NotStarted;
            }
            Status = status;
            //Id = Int32.Parse(parsed[5]);
            if (!Int32.TryParse(parsed[5], out int id))
            {
                throw new FormatException();
            }
            Id = id;
           
        }

        public static Match Create(string line)
        {
            if (line!=null)
            {
                return new Match(line);
            }
            else
            {
                throw new ArgumentNullException();
            }
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
            StringBuilder sb = new StringBuilder();
            if (ParticipantOne!=null)
            {
                sb.Append($"\"{ParticipantOne.Id}\",");
            }
            else
            {
                sb.Append($"\"0\",");
            }
            if (ParticipantTwo != null)
            {
                sb.Append($"\"{ParticipantTwo.Id}\",");
            }
            else
            {
                sb.Append($"\"0\",");
            }

            sb.Append($"\"{_result}\",");
            sb.Append($"\"{Status.ToString()}\",");
            sb.Append($"\"{Layer.ToString()}\",");
            return sb.ToString();
        }
    }
}
