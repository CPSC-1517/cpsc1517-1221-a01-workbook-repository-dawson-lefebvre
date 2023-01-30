using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystemClassLibrary
{
    internal class Goalie : Player
    {
        private double _savePercentage;
        public double GoalsAgainstAverage { get; set; }
        //public double SavePercentage { get; set; }
        public int Shutouts { get; private set; }

        public double SavePercentage
        {
            get { return _savePercentage; }
            set
            {
                if(value < 0 || value > 1)
                {
                    throw new ArgumentException("SavePercentage must be between 0 and 1");
                }
            }
        }
        public Goalie(int playerNo, string name, int gamesPlayed) : base(playerNo, name, Position.G, gamesPlayed)
        {
            
        }

        public void AddShutout()
        {
            Shutouts++;
        }
    }
}
