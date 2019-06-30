using Autofac;

namespace RobotProgramming
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            return RegisterServices().Build();
        }

        private static ContainerBuilder RegisterServices()
        {
            var assembly = typeof(ContainerConfig).Assembly;
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(assembly);

            return builder;
        }
    }
}
