using Autofac;
using System.Reflection;
using TimeManager.ProcessingEngine.Data;
using TimeManager.ProcessingEngine.Processors;

namespace TimeManager.ProcessingEngine.Services.container
{
    public class ContainerConfig
    {
        public static IContainer CreateProcessorsContainer(DataContext _context, ILogger<Processor> _logger)
        {
            var container = new ContainerBuilder();


            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "TimeManager.ProcessingEngine.Processors.TaskProcessors")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name))
                .WithParameter(new TypedParameter(typeof(DataContext), _context))
                .WithParameter(new TypedParameter(typeof(ILogger<Processor>), _logger));

            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "TimeManager.ProcessingEngine.Processors.TaskSetProcessors")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name))
                .WithParameter(new TypedParameter(typeof(DataContext), _context))
                .WithParameter(new TypedParameter(typeof(ILogger<Processor>), _logger));

            return container.Build();
        }
    }
}
