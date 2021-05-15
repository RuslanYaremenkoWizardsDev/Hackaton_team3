using System;
using System.Text;

namespace Hackaton_team3
{
    public class Participant : ISerializableToDB
    {
        private string _name;
        public string Name {
            get { return _name; }
            set {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else _name = value;            
             }
        }
        public Division Division { get; set; }

        private Participant(string line)
        {
            string[] parsed = line.Split(",".ToCharArray());
            if (!Enum.TryParse(parsed[1], out Division division))
            {
                division = Division.Middle;
            }

            Name = parsed[0];
            Division = division;
        }

        public static Participant Create(string line)
        {
            if (line!=null)
            {
                return new Participant(line);
            }
            else
            {
                throw new ArgumentNullException("Line is null");
            }
        }

        public Participant(string name, Division d)
        {
            Name = name;
            Division = d;
        }
        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Participant)
            {
                Participant temp = (Participant)obj;
                if (Name == temp.Name && Division == temp.Division)
                {
                    result = true;
                }
            }
            return result;
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\"{_name}\",\"{Division.ToString()}\"");
            return sb.ToString();
        }

 
    }
}
