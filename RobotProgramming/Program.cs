using Autofac;
using RobotProgramming.Commands;
using RobotProgramming.Rooms;
using System;

namespace RobotProgramming
{
    public class Program
    {
        public static bool TimeToStop { get; set; } = false;

        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var commandHandler = scope.Resolve<ICommandHandler>();

                Console.Write("Set room size(ex. 5x5): ");
                var input = Console.ReadLine();
                commandHandler.ReadCommand("SetRoom " + input);

                Console.Write("Set robot start position(ex. (0,0,E)): ");
                input = Console.ReadLine();
                commandHandler.ReadCommand("SetRobotStart " + input);

                while (!TimeToStop)
                {
                    commandHandler.DisplayCommands();

                    input = Console.ReadLine();
                    commandHandler.ReadCommand(input);

                    Console.WriteLine();
                }
            }
        }
    }
}
