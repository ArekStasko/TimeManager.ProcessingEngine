using Autofac;
using System.Reflection;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Services.container
{
    public class ContainerConfig
    {
        public static IContainer CreateProcessorsContainer(DataContext _context)
        {
            var container = new ContainerBuilder();


            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "TimeManager.ProcessingEngine.Processors")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name))
                .WithParameter(new TypedParameter(typeof(DataContext), _context));


            return container.Build();
        }
    }
}
