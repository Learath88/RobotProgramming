using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotProgramming.Rooms;
using RobotProgramming.Rooms.Models;

namespace RobotProgrammingTest
{
    [TestClass]
    public class RoomHandlerTests
    {
        private RoomHandler _RoomHandler;
        private PrivateObject _RoomHandlerPrivateObject;
        
        [TestInitialize]
        public void TestSetup()
        {
            _RoomHandler = new RoomHandler();
            _RoomHandlerPrivateObject = new PrivateObject(_RoomHandler);
        }

        [TestMethod]
        public void SetRoomSize()
        {
            int expectedX = 4;
            int expectedY = 6;

            _RoomHandler.SetRoomSize(expectedX, expectedY);

            var room = _RoomHandlerPrivateObject.GetField("_Room") as Room;

            Assert.AreEqual(expectedX, room.X);
            Assert.AreEqual(expectedY, room.Y);
        }

        [DataRow(1, 1, true)]
        [DataRow(-1, 1, false)]
        [DataRow(1, 3, true)]
        [DataRow(1, 5, false)]
        [DataTestMethod]
        public void CheckBoundaries(int checkX, int checkY, bool expected)
        {
            var room = _RoomHandlerPrivateObject.GetField("_Room") as Room;
            room.X = 5;
            room.Y = 5;

            var actual = _RoomHandler.CheckBoundaries(checkX, checkY);

            Assert.AreEqual(expected, actual);
        }
    }
}
