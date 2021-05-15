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
        private string _location;
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
        Dictionary<Participant, int> points;
        public Division tournamentDivision { get; set; }
        public string Location
        {
            get { return _location; }
            set
            {
                if (value==null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    _location = value;
                }           
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
                if (Name==temp.Name && Description == temp.Description && Start==temp.Start && EndRegistration == temp.EndRegistration && Division == temp.Division)
                {
                    result = true;
                }
                
            }
            return result;


        }
    }
}
