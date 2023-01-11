using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystemClassLibrary
{
    internal class Team
    {
        Conference _conference;
        Division _division;
        string _name;
        string _city;
        string _arena;

        public Conference Conference
        {
            get
            {
                return _conference;
            }
            private set
            {
                _conference = value;
            }
        }

        public Division Division
        {
            get
            {
                return _division;
            }
            set
            {
                _division = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.All(char.IsLetter))
                {

                }
            }
        }
    }
}
