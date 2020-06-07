using Autofac;

namespace CareKickOff
{
    internal class AppContainer
    {
        public static IContainer Container { get; set; }

        public static void Initialize()
        {
            var containerBuilder = new ContainerBuilder();

            RegisterModules(containerBuilder);

            Container = containerBuilder.Build();

        }

        private static void RegisterModules(ContainerBuilder containerBuilder)
        { 
            containerBuilder.RegisterModule<DependencyModule>();
        }
    }
}
