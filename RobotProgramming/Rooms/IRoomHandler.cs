namespace RobotProgramming.Rooms
{
    public interface IRoomHandler
    {
        void SetRoomSize(int x, int y);
        bool CheckBoundaries(int x, int y);
    }
}