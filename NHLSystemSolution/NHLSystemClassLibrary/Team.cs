using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystemClassLibrary
{
    internal class Team
    {
        string _name;
        string _city;
        string _arena;

        public Conference Conference { get; set; }

        public Division Division { get; set; }

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
                    _name = value;
                }
                else
                {
                    throw new Exception("Name muts only contain letters");
                }
            }
        }

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if(value.Length >= 3)
                {
                    _city = value;
                }
                else
                {
                    throw new Exception("City must be longer than 2 characters");
                }
            }
        }

        public string Arena
        {
            get
            {
                return _arena;
            }
            set
            {
                if(value == null)
                {
                    throw new Exception("Cannot be blank");
                }
                else
                {
                    _arena = value;
                }
            }
        }

        public Team(Conference conference, Division division, string name, string city, string arena)
        {
            Conference = conference;
            Division = division;
            Name = name;
            City = city;
            Arena = arena;
        }
    }
}
