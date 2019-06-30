using Autofac;

namespace RobotProgramming.Robots
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RobotHandler>().As<IRobotHandler>().SingleInstance();
        }
    }
}
