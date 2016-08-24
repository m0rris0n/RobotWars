using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class RobotOperator
    {
        Robot Robot { get; set; }
        Arena Arena { get; set; }

        public RobotOperator(Robot robot, Arena arena)
        {
            Robot = robot;
            Arena = arena;
        }

        /// <summary>
        /// Based on the heading variable of the local Robot object, the method checks the 
        /// Robot's relevent coordinates against the boundaries of the arena to detect for 
        /// collisions. Where there is space to move, the Robot's appropriate coordinate is 
        /// incremented/reduced as appropriate.
        /// </summary>
        /// <returns>The method returns a bool value denoting whether the robot has been 
        /// able to move (true) or has collided with the edge (false).</returns>
        bool move()
        {
            switch (Robot.Heading)
            {
                case "N":
                    if (Robot.Y < Arena.MaxY)
                    {
                        Robot.Y++;
                        return true;
                    }
                    return false;
                case "E":
                    if (Robot.X < Arena.MaxX)
                    {
                        Robot.X++;
                        return true;
                    }
                    return false;
                case "S":
                    if (Robot.Y > 0)
                    {
                        Robot.Y--;
                        return true;
                    }
                    return false;
                case "W":
                    if (Robot.X > 0)
                    {
                        Robot.X--;
                        return true;
                    }
                    return false;
                default:
                    return false;

            }
        }

        /// <summary>
        /// Will read L or R from the direction parameter and then change the heading accordingly
        /// </summary>
        /// <param name="direction">"L" or "R" is expected</param>
        void rotate(string direction)
        {
            if (direction == "L")
            {
                switch (Robot.Heading)
                {
                    case "N":
                        Robot.Heading = "W";
                        break;
                    case "W":
                        Robot.Heading = "S";
                        break;
                    case "S":
                        Robot.Heading = "E";
                        break;
                    case "E":
                        Robot.Heading = "N";
                        break;
                    default:
                        break;
                }
            }
            else if (direction == "R")
            {
                switch (Robot.Heading)
                {
                    case "N":
                        Robot.Heading = "E";
                        break;
                    case "W":
                        Robot.Heading = "N";
                        break;
                    case "S":
                        Robot.Heading = "W";
                        break;
                    case "E":
                        Robot.Heading = "S";
                        break;
                    default:
                        break;

                }
            }
        }

        /// <summary>
        /// Cycles through the instruction string and acts according to the character discovered. 
        /// Where "M" is found operator attempts the move function, and if it fails, increases the 
        /// robot's penalities by 1.
        /// Where an "L" or "R" are read , the rotate method is fired with the rotatation
        /// direction as the parameter.
        /// </summary>
        /// <param name="instructions">the M/L/R combo string for the robot's movement</param>
        public string executeInstructions(string instructions)
        {
            foreach (char c in instructions)
            {

                if (c.ToString() == "M")
                {
                    if (move() == false)
                    {
                        Robot.Penalties++;
                    }
                }
                else
                {
                    rotate(c.ToString());
                }
            }
            return Robot.ReportLocation();
        }

        //Returns the penalities variable from within the local Robot object
        public int reportPenalties()
        {
            return Robot.Penalties;
        }


    }
}