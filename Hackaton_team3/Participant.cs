using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton_team3
{
    public class Participant
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
    }
}
