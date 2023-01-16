using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystemClassLibrary
{
    internal class Player
    {
        private int _playerNo, _gamesPlayed, _goals, _assists;
        private string _name;
        public Position Position { get; set; }

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

        public int PlayerNo
        {
            get { return _playerNo; }
            set 
            {
                if (value <= 0 || value > 98)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Player number must be 1-98");
                }
                else
                {
                    _playerNo = value;
                }
            }
        }

        public int GamesPlayed
        {
            get { return _gamesPlayed; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Games played cannot be less than 0");
                }
                else
                {
                    _gamesPlayed = value;
                }
            }
        }
        public int Goals
        {
            get { return _goals; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Goals cannot be less than 0");
                }
                else
                {
                    _goals = value;
                }
            }
        }

        public int Assists
        {
            get { return _assists; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Assists cannot be less than 0");
                }
                else
                {
                    _assists = value;
                }
            }
        }

        public int Points
        {
            get { return Goals + Assists; }
        }

        public Player(int playerNo, string name, Position position, int gamesPlayed, int goals, int assists)
        {
            PlayerNo = playerNo;
            Name = name;
            Position = position;
            GamesPlayed = gamesPlayed;
            Goals = goals;
            Assists = assists;
        }

        //METHODS
        public void AddGoal()
        {
            _goals++;
        }

        public void AddAssist()
        {
            _assists++;
        }

    }
}
