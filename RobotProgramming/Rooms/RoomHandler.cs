using RobotProgramming.Rooms.Models;

namespace RobotProgramming.Rooms
{
    public class RoomHandler : IRoomHandler
    {
        private readonly Room _Room;

        public RoomHandler()
        {
            _Room = new Room();
        }

        public bool CheckBoundaries(int x, int y)
        {
            if (x < 0 || x >= _Room.X) return false;
            if (y < 0 || y >= _Room.Y) return false;
            return true;
        }

        public void SetRoomSize(int x, int y)
        {
            _Room.X = x;
            _Room.Y = y;
        }
    }
}
