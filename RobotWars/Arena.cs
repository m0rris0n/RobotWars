using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Arena
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        //Size of arena is determined upon initialisation
        public Arena(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }
    }
}
