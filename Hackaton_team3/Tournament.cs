using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton_team3
{
    public class Tournament
    {
        private string _name;
        private string _description;
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

        public override bool Equals(object obj)
        {
            bool result = false;
            
        }
    }
}
