﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobotWars.Test
{
    [TestClass]
    public class RobotFullActionTest
    {
        Arena _testArena;

        [TestInitialize()]
        public void Initialize()
        {
            _testArena = new Arena(4, 4);
        }

        [TestMethod]
        public void Scenario1()
        {
            //Arrange
            RobotOperator robotOperator = new RobotOperator(
                new Robot(0, 2, "E"),
                _testArena
                );

            //Act
            var location = robotOperator.ExecuteInstructions("MLMRMMMRMMRR");
            var penalties = robotOperator.ReportPenalties();

            //Assert
            Assert.AreEqual(location, "4,1,N");
            Assert.AreEqual(0, penalties);

        }

        [TestMethod]
        public void Scenario2()
        {
            //Arrange
            RobotOperator robotOperator = new RobotOperator(
                new Robot(4, 4, "S"),
                _testArena
                );

            //Act
            var location = robotOperator.ExecuteInstructions("LMLLMMLMMMRMM");
            var penalties = robotOperator.ReportPenalties();

            //Assert
            Assert.AreEqual(location, "0,1,W");
            Assert.AreEqual(1, penalties);

        }

        [TestMethod]
        public void Scenario3()
        {
            //Arrange
            RobotOperator robotOperator = new RobotOperator(
                new Robot(2, 2, "W"),
                _testArena
                );

            //Act
            var location = robotOperator.ExecuteInstructions("MLMLMLMRMRMRMRM");
            var penalties = robotOperator.ReportPenalties();

            //Assert
            Assert.AreEqual(location, "2,2,N");
            Assert.AreEqual(0, penalties);

        }

        [TestMethod]
        public void Scenario4()
        {
            //Arrange
            RobotOperator robotOperator = new RobotOperator(
                new Robot(1, 3, "N"),
                _testArena
                );

            //Act
            var location = robotOperator.ExecuteInstructions("MMLMMLMMMMM");
            var penalties = robotOperator.ReportPenalties();

            //Assert
            Assert.AreEqual(location, "0,0,S");
            Assert.AreEqual(3, penalties);

        }
    }
}
