using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton_team3
{
    public class Tournament
    {
        private string _name;
        private string _description;
        private string _location;
        public TournamentMode Mode { get; set; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != null)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentNullException("Value is null");
                }
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value != null)
                {
                    _description = value;
                }
                else
                {
                    throw new ArgumentNullException("Value is null");
                }
            }
        }
        public DateTime Start { get; set; }
        public DateTime EndRegistration { get; set; }
        public Division Division { get; set; }

        Dictionary<Participant, int> points; //Не сериализируется
        public string Location
        {
            get { return _location; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    _location = value;
                }
            }
        }
        List<Match> matches; //Не сериализируется
        public Scenario Scenario { get; set; }

        public Status Status { get; set; }

        public Tournament()
        {
            matches = new List<Match>(); 
        }

        public Tournament(string name, DateTime start, DateTime endRegistration)
        {
            Name = name;
            Start = start;
            EndRegistration = endRegistration;
            matches = new List<Match>();
            Mode = TournamentMode.Tournament;
            Description = string.Empty;
            Division = Division.Middle;
            points = new Dictionary<Participant, int>();
            Location = string.Empty;
            Scenario = Scenario.Bo1;
            Status = Status.NotStarted;

        }

        private Tournament(string line)
        {
            

            string[] parsed = line.Split(",".ToCharArray());
            Name = parsed[0];
            Description = parsed[1];
            if (!Enum.TryParse(parsed[2], out TournamentMode tournamentMode))
            {
                tournamentMode = TournamentMode.Tournament;
            }
            Mode = tournamentMode;
            _location = parsed[3];
            Start = DateTime.ParseExact(parsed[4], "yyyy.MM.dd", CultureInfo.InvariantCulture);
            EndRegistration = DateTime.ParseExact(parsed[5], "yyyy.MM.dd", CultureInfo.InvariantCulture);
            if (!Enum.TryParse(parsed[6], out Division tournamentDivision))
            {
                tournamentDivision = Division.Middle;
            }
            Division = tournamentDivision;
            if (!Enum.TryParse(parsed[7], out Scenario tournamentScenario))
            {
                tournamentScenario = Scenario.Bo1;             
            }
            Scenario = tournamentScenario;
            if (!Enum.TryParse(parsed[8], out Status tournamentStatus))
            {
                tournamentStatus = Status.NotStarted;
            }
            Status = tournamentStatus;
        }

        public static Tournament Create(string line)
        {
            if (line != null)
            {
                return new Tournament(line);
            }
            else
            {
                throw new ArgumentNullException("Line is null");
            }
        }

        //public void AddPointsToTeam(Participant team, int p)
        //{
        //    if (!points.ContainsKey(team))
        //    {
        //        points.Add(team, p);
        //    }
        //    else
        //    {
        //        points[team] = points[team] + p;
        //    }
        //}

        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Tournament)
            {
                Tournament temp = (Tournament)obj;
                if (Name == temp.Name && Description == temp.Description && Start == temp.Start && EndRegistration == temp.EndRegistration && Division == temp.Division)
                {
                    result = true;
                }

            }
            return result;
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\"{_name}\",");
            sb.Append($"\"{_description}\",");
            sb.Append($"\"{Mode.ToString()}\",");
            sb.Append($"\"{_location}\",");
            sb.Append($"\"{Start.ToString("yyyy.MM.dd")}\",");
            sb.Append($"\"{EndRegistration.ToString("yyyy.MM.dd")}\",");
            sb.Append($"\"{Division.ToString()}\",");
            sb.Append($"\"{Scenario.ToString()}\",");
            sb.Append($"\"{Status.ToString()}\"");
            return sb.ToString();
        }
    }
}
