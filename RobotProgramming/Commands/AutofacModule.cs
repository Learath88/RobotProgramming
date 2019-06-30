using Autofac;

namespace RobotProgramming.Commands
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandHandler>().As<ICommandHandler>().SingleInstance();
        }
    }
}
