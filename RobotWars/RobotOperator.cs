using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class RobotOperator
    {
        Robot _robot;
        Arena _arena;

        public RobotOperator(Robot robot, Arena arena)
        {
            _robot = robot;
            _arena = arena;
        }

        /// <summary>
        /// Based on the heading variable of the local Robot object, the method checks the 
        /// Robot's relevent coordinates against the boundaries of the arena to detect for 
        /// collisions. Where there is space to move, the Robot's appropriate coordinate is 
        /// incremented/reduced as appropriate.
        /// </summary>
        /// <returns>The method returns a bool value denoting whether the robot has been 
        /// able to move (true) or has collided with the edge (false).</returns>
        public bool Move()
        {
            switch (_robot.Heading)
            {
                case "N":
                    if (_robot.Y < _arena.MaxY)
                    {
                        _robot.Y++;
                        return true;
                    }
                    return false;
                case "E":
                    if (_robot.X < _arena.MaxX)
                    {
                        _robot.X++;
                        return true;
                    }
                    return false;
                case "S":
                    if (_robot.Y > 0)
                    {
                        _robot.Y--;
                        return true;
                    }
                    return false;
                case "W":
                    if (_robot.X > 0)
                    {
                        _robot.X--;
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
        public void Rotate(string direction)
        {
            if (direction == "L")
            {
                switch (_robot.Heading)
                {
                    case "N":
                        _robot.Heading = "W";
                        break;
                    case "W":
                        _robot.Heading = "S";
                        break;
                    case "S":
                        _robot.Heading = "E";
                        break;
                    case "E":
                        _robot.Heading = "N";
                        break;
                    default:
                        break;
                }
            }
            else if (direction == "R")
            {
                switch (_robot.Heading)
                {
                    case "N":
                        _robot.Heading = "E";
                        break;
                    case "W":
                        _robot.Heading = "N";
                        break;
                    case "S":
                        _robot.Heading = "W";
                        break;
                    case "E":
                        _robot.Heading = "S";
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
        public string ExecuteInstructions(string instructions)
        {
            foreach (char c in instructions)
            {

                if (c.ToString() == "M")
                {
                    if (Move() == false)
                    {
                        _robot.Penalties++;
                    }
                }
                else
                {
                    Rotate(c.ToString());
                }
            }
            return _robot.ReportLocation();
        }

        //Returns the penalities variable from within the local Robot object
        public int ReportPenalties()
        {
            return _robot.Penalties;
        }


    }
}