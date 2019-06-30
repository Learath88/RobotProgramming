using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotProgramming.Robots;
using RobotProgramming.Robots.Enums;
using RobotProgramming.Robots.Models;
using RobotProgramming.Rooms;

namespace RobotProgrammingTest
{
    [TestClass]
    public class RobotHandlerTests
    {
        private RobotHandler _RobotHandler;
        private PrivateObject _RobotHandlerPrivateObject;

        Mock<IRoomHandler> _roomHandler;

        [TestInitialize]
        public void TestSetup()
        {
            _roomHandler = new Mock<IRoomHandler>();

            _roomHandler.Setup(x => x.CheckBoundaries(It.IsAny<int>(), It.IsAny<int>())).Returns((int x, int y) => 
            {
                if (x < 0 || x >= 5) return false;
                if (y < 0 || y >= 5) return false;
                return true;
            });

            _RobotHandler = new RobotHandler(_roomHandler.Object);
            _RobotHandlerPrivateObject = new PrivateObject(_RobotHandler);
        }
        
        [DataRow(Direction.W, "LLL", Direction.N)]
        [DataRow(Direction.N, "LL", Direction.S)]
        [DataRow(Direction.N, "RRR", Direction.W)]
        [DataRow(Direction.W, "RR", Direction.E)]
        [DataTestMethod]
        public void Move_Direction(Direction start, string turn, Direction end) 
        {
            var robot = _RobotHandlerPrivateObject.GetField("_Robot") as Robot;
            robot.Direction = start;

            _RobotHandler.Move(turn);

            Assert.AreEqual(end, robot.Direction);
        }

        [DataRow(0, 0, Direction.W, "FF", 0, 0)]
        [DataRow(0, 0, Direction.E, "FF", 2, 0)]
        [DataRow(0, 3, Direction.E, "FFLFF", 2, 1)]
        [DataTestMethod]
        public void Move_Walk(int startX, int startY, Direction direction, string moves, int endX, int endY)
        {
            var robot = _RobotHandlerPrivateObject.GetField("_Robot") as Robot;
            robot.Direction = direction;
            robot.X = startX;
            robot.Y = startY;

            _RobotHandler.Move(moves);

            Assert.AreEqual(endX, robot.X);
            Assert.AreEqual(endY, robot.Y);
        }

        [TestMethod]
        public void SetStartPosition()
        {
            int expectedX = 2;
            int expectedY = 3;
            Direction expectedDirection = Direction.S;

            _RobotHandler.SetStartPosition(expectedX, expectedY, expectedDirection);

            var robot = _RobotHandlerPrivateObject.GetField("_Robot") as Robot;

            _roomHandler.Verify(x => x.CheckBoundaries(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

            Assert.AreEqual(expectedX, robot.X);
            Assert.AreEqual(expectedY, robot.Y);
            Assert.AreEqual(expectedDirection, robot.Direction);

        }
    }
}
