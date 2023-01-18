using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystemClassLibrary
{
    internal static class Ultilities
    {
        static public bool IsPositiveOrZero(int value)
        {
            return (value >= 0);
        }

        static public bool IsPositiveOrZero(double value)
        {
            return (value >= 0);
        }
    }
}
