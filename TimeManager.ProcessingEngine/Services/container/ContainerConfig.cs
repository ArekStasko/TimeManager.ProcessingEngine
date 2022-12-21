using Autofac;
using System.Reflection;

namespace TimeManager.ProcessingEngine.Services.container
{
    public class ContainerConfig
    {
        public static IContainer CreateProcessorsContainer()
        {
            var container = new ContainerBuilder();

            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "TimeManager.ProcessingEngine.Processors")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return container.Build();
        }
    }
}
