using RobotProgramming.Robots.Enums;

namespace RobotProgramming.Robots
{
    public interface IRobotHandler
    {
        void Move(string moves);
        void SetStartPosition(int x, int y, Direction direction);
        string GetPosition();
    }
}