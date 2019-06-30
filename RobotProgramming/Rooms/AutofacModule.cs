using Autofac;
using RobotProgramming.Rooms;

namespace RobotProgramming.Rooms
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RoomHandler>().As<IRoomHandler>().SingleInstance();
        }
    }
}
