using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Hackaton_team3
{
    public class Tournament : ISerializableToDB
    {
        private string _name;
        private string _description;
        private string _location;

        public ParticipantsAmount MaxAmount { get; set; } 
        public TournamentMode Mode { get; set; }
        public int Amount { get; set; }
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
        public Dictionary<Participant, int> Points { get; set; }
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                if (value != null)
                {
                    _location = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
        public List<Match> Matches { get; set; }
        public Scenario Scenario { get; set; }

        public Status Status { get; set; }

        public int Id { get; set; }

        public Tournament()
        {

        }

        public Tournament(string name,int amount, DateTime start, DateTime endRegistration)
        {
            Name = name;
            Start = start;
            EndRegistration = endRegistration;
            Matches = new List<Match>();
            Mode = TournamentMode.Tournament;
            Description = string.Empty;
            Division = Division.Middle;
            Points = new Dictionary<Participant, int>();
            Location = string.Empty;
            Scenario = Scenario.Bo1;
            Status = Status.NotStarted;
            Amount = amount;
            Match[] newMatch = new Match[Amount / 2];
            for (int i = 0; i < newMatch.Length; i++)
            {
                newMatch[i] = new Match();
            }

            SetLocationMatch(newMatch, 0, 0);
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

        public static Tournament Create(string name,int amount, DateTime start, DateTime endRegistration)
        {
            if (name != null)
            {
                return new Tournament(name,amount, start, endRegistration);
            }

            throw new ArgumentNullException("Name is null");
        }

        public void SetLocationMatch(Match[] allMatch, int x, int y)
        {
            int tempY = y;
            foreach (Match match in allMatch)
            {
                tempY += 70 + 50;
                match.Location = new System.Drawing.Point(x, tempY);
            }

            Matches.AddRange(allMatch);
            int index = allMatch.Length / 2;
            Match[] newMatch = new Match[index];
            for (int i = 0; i < index; i++)
            {
                newMatch[i] = new Match();
            }

            if (allMatch.Length > 1)
            {
                SetLocationMatch(newMatch, x + 100 + 50, y + 70);

            }
        }
        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Tournament)
            {
                Tournament temp = (Tournament)obj;
                if (Name == temp.Name
                    && Description == temp.Description
                    && Start == temp.Start
                    && EndRegistration == temp.EndRegistration
                    && Division == temp.Division)
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
