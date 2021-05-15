using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton_team3
{
    public class Participant
    {
        public String Name { get; set; }
        public Division Division { get; set; }

        public Participant(string name, Division d)
        {
            Name = name;
            Division = d;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Participant))
                return false;
            Participant temp = (Participant)obj;
            if (temp.Name != Name)
                return false;
            if (!temp.Division.Equals(Division))
                return false;
            return true;
        }
    }
}
