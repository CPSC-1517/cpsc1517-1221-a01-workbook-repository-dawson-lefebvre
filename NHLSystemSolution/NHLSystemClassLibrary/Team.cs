using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystemClassLibrary
{
    public class Team
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
                if ((value.All(char.IsLetter) || value.Any(char.IsWhiteSpace)) && !string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be blank");
                }
                else
                {
                    throw new Exception("Name must contain only letters and spaces");
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("City can not be blank");
                }
                else
                {
                    if (value.Length >= 3)
                    {
                        _city = value;
                    }
                    else
                    {
                        throw new Exception("City must be longer than 2 characters");
                    }
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
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Value cannot be null.");
                }
                else
                {
                    _arena = value.Trim();
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

        public Team(string name)
        {
            Name = name;
        }
    }
}
