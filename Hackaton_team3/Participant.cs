using System;

namespace Hackaton_team3
{
    public class Participant
    {
        private string _name;
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
        public Division Division { get; set; }

        private Participant(string name, Division d)
        {
            Name = name;
            Division = d;
        }

        public static Participant Create(string name, Division division)
        {
            if (name != null)
            {
                return new Participant(name, division);
            }

            throw new ArgumentNullException("String name is null");
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
    }
}
