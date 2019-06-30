using RobotProgramming.Commands.Enums;
using RobotProgramming.Robots;
using RobotProgramming.Robots.Enums;
using RobotProgramming.Rooms;
using System;
using System.Linq;

namespace RobotProgramming.Commands
{
    public class CommandHandler : ICommandHandler
    {
        private readonly IRoomHandler _RoomHandler;
        private readonly IRobotHandler _RobotHandler;

        public CommandHandler(IRoomHandler roomHandler,
            IRobotHandler robotHandler)
        {
            _RoomHandler = roomHandler;
            _RobotHandler = robotHandler;
        }

        public void DisplayCommands()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine(" SETROOM".PadRight(20) + "ex. SETROOM 5x5");
            Console.WriteLine(" SETROBOTSTART".PadRight(20) + "ex. SETROBOTSTART (0,0,E)");
            Console.WriteLine(" MOVE".PadRight(20) + "ex. MOVE LFR");
            Console.WriteLine(" QUIT");
        }

        public void ReadCommand(string input)
        {
            var split = input.Split(' ');

            if (split.Length < 2)
            {
                // TODO:
                return;
            }

            if (!Enum.TryParse(split[0].ToUpper(), out CommandType commandType))
            {
                // TODO:
                return;
            }

            switch (commandType)
            {
                case CommandType.SETROOM:
                    var xy = split[1].Split('x');

                    if (split.Length < 2)
                    {
                        // TODO:
                        return;
                    }

                    var x = Convert.ToInt32(xy[0]);
                    var y = Convert.ToInt32(xy[1]);
                    _RoomHandler.SetRoomSize(x, y);
                    break;
                case CommandType.SETROBOTSTART:
                    var pos = split[1].Replace("(", "").Replace(")", "").Split(',');
                    var x1 = Convert.ToInt32(pos[0]);
                    var y1 = Convert.ToInt32(pos[1]);
                    if (!Enum.TryParse(pos[2].ToUpper(), out Direction dir))
                    {
                        // TODO:
                        return;
                    }
                    _RobotHandler.SetStartPosition(x1, y1, dir);
                    break;
                case CommandType.MOVE:
                    var moves = split[1].ToUpper();
                    if (moves.Any(c => c != 'R' && c != 'L' && c != 'F'))
                    {
                        // TODO:
                        return;
                    }
                    _RobotHandler.Move(moves);
                    Console.WriteLine(_RobotHandler.GetPosition());
                    break;
                case CommandType.QUIT:
                    Program.TimeToStop = true;
                    break;
                default:
                    // TODO:
                    break;
            }
        }

    }
}
