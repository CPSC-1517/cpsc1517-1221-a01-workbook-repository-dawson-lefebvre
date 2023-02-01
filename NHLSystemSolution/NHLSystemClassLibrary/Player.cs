using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NHLSystemClassLibrary
{
    public class Player
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
                    throw new ArgumentNullException(nameof(value), "Name cannot be blank");
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

        //CONTRUCTORS
        public Player(int playerNo, string name, Position position, int gamesPlayed, int goals, int assists)
        {
            PlayerNo = playerNo;
            Name = name;
            Position = position;
            GamesPlayed = gamesPlayed;
            Goals = goals;
            Assists = assists;
        }

        public Player(int playerNo, string name, Position position, int gamesPlayed)
        {
            PlayerNo = playerNo;
            Name = name;
            Position = position;
            GamesPlayed = gamesPlayed;
        }

        public Player() { }

        //METHODS
        public void AddGoal()
        {
            _goals++;
        }

        public void AddAssist()
        {
            _assists++;
        }

        public void AddGamesPlayed()
        {
            _gamesPlayed++;
        }

        public override string ToString()
        {
            // Return a CSV list of the properties used by the constructor
            return $"{PlayerNo},{Name},{Position},{GamesPlayed},{Goals},{Assists}";
        }

        public static Player Parse(string csvLine)
        {
            const char Delimiter = ',';
            const int ExpectedColumnCount = 6;
            string[] tokens = csvLine.Split(Delimiter);
            // Verify that the length of the array 
            if (tokens.Length != ExpectedColumnCount)
            {
                throw new FormatException($"CSV line must contain exactly {ExpectedColumnCount} values.");

            }

            int playerNo = int.Parse(tokens[0]);
            string name = tokens[1];
            Position position = Enum.Parse<Position>(tokens[2]);
            int gamesPlayed = int.Parse(tokens[3]);
            int goals = int.Parse(tokens[4]);
            int assists = int.Parse(tokens[5]);

            return new Player(playerNo, name, position, gamesPlayed, goals, assists);// new Player();
        }

        public static bool TryParse(string csvLine, out Player currentPlayer)
        {
            bool result = false;
            const char Delimiter = ',';
            const int ExpectedColumnCount = 6;
            string[] tokens = csvLine.Split(Delimiter);
            // Verify that the length of the array 
            if (tokens.Length != ExpectedColumnCount)
            {
                throw new FormatException($"CSV line must contain exactly {ExpectedColumnCount} values.");
            }
            
            try
            {
                currentPlayer = Player.Parse(csvLine);
                result = true;
            }
            catch(FormatException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception($"Player TryParse failed with exception {ex.Message}");
            }
            return result;
        }
    }
}
