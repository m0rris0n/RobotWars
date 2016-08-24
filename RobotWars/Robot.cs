using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Heading { get; set; }
        public int Penalties { get; set; }

        /// <summary>
        /// The construtor initialises the robot, providing it's location, heading
        /// and instructions.
        /// </summary>
        /// <param name="x">X coordinate, int between 0 and maximum arena X coordinate</param>
        /// <param name="y">Y coordinate, int between 0 and maximum arena Y coordinate</param>
        /// <param name="heading">The cardinal direction the robot is facing as a string</param>
        public Robot(int x, int y, string heading)
        {
            X = x;
            Y = y;
            Heading = heading;
            Penalties = 0;
        }

        /// <summary>
        /// The Robot reports all it's location based properties for review
        /// </summary>
        /// <returns>The Robot's properties are returned as a comma delimited string</returns>
        public string ReportLocation()
        {
            return X + "," + Y + "," + Heading;
        }

    }
}
