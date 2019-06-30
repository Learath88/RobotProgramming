using RobotProgramming.Robots.Enums;
using RobotProgramming.Robots.Models;
using RobotProgramming.Rooms;

namespace RobotProgramming.Robots
{
    public class RobotHandler : IRobotHandler
    {
        private readonly IRoomHandler _RoomHandler;

        private readonly Robot _Robot;

        public RobotHandler(IRoomHandler roomHandler)
        {
            _RoomHandler = roomHandler;
            _Robot = new Robot();
        }

        public void Move(string moves)
        {
            foreach(var move in moves)
            {
                switch (move)
                {
                    case 'L':
                        var leftDirection = (int)_Robot.Direction - 1;
                        if(leftDirection < 0)
                        {
                            leftDirection = 3;
                        }
                        _Robot.Direction = (Direction)leftDirection;
                        break;

                    case 'R':
                        var rightDirection = (int)_Robot.Direction + 1;
                        if (rightDirection > 3)
                        {
                            rightDirection = 0;
                        }
                        _Robot.Direction = (Direction)rightDirection;
                        break;

                    case 'F':
                        var nextX = _Robot.X;
                        var nextY = _Robot.Y;

                        switch (_Robot.Direction)
                        {
                            case Direction.N:
                                nextY--;
                                MaybeMoveRobot(nextX, nextY);
                                break;
                            case Direction.E:
                                nextX++;
                                MaybeMoveRobot(nextX, nextY);
                                break;
                            case Direction.S:
                                nextY++;
                                MaybeMoveRobot(nextX, nextY);
                                break;
                            case Direction.W:
                                nextX--;
                                MaybeMoveRobot(nextX, nextY);
                                break;
                            default:
                                // not possible
                                break;
                        }
                        break;

                    default:
                        // TODO:
                        break;
                }
            }
        }

        private void MaybeMoveRobot(int x, int y)
        {
            if (_RoomHandler.CheckBoundaries(x, y))
            {
                _Robot.X = x;
                _Robot.Y = y;
            }
        }

        public void SetStartPosition(int x, int y, Direction direction)
        {
            if(!_RoomHandler.CheckBoundaries(x, y))
            {
                // TODO:
                return;
            }

            _Robot.X = x;
            _Robot.Y = y;
            _Robot.Direction = direction;
        }

        public string GetPosition()
        {
            return $"{_Robot.X} {_Robot.Y} {_Robot.Direction}";
        }
    }
}
