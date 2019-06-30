namespace RobotProgramming.Commands
{
    public interface ICommandHandler
    {
        void ReadCommand(string input);
        void DisplayCommands();
    }
}