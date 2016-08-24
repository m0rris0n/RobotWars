using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    class Program
    {
        static void Main(string[] args)
        {
            RobotOperator robotOperator = new RobotOperator(
                new Robot(0, 2, "E"),
                new Arena(4, 4)
                );
                        
            var location = robotOperator.ExecuteInstructions("MLMRMMMRMMRR");
            var penalties = robotOperator.ReportPenalties();
        }
    }
}
