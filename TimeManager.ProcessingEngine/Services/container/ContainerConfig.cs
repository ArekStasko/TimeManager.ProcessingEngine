using Autofac;
using System.Reflection;
using AutoMapper;
using TimeManager.ProcessingEngine.Data;
using TimeManager.ProcessingEngine.Processors;

namespace TimeManager.ProcessingEngine.Services.container
{
    public class ContainerConfig
    {
        public static IContainer CreateProcessorsContainer(DataContext _context, ILogger<Processor> _logger, IMapper _mapper)
        {
            var container = new ContainerBuilder();

            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "TimeManager.ProcessingEngine.Processors.UserProcessors")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name))
                .WithParameter(new TypedParameter(typeof(DataContext), _context))
                .WithParameter(new TypedParameter(typeof(ILogger<Processor>), _logger))
                .WithParameter(new TypedParameter(typeof(IMapper), _mapper));
            
            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "TimeManager.ProcessingEngine.Processors.TaskProcessors")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name))
                .WithParameter(new TypedParameter(typeof(DataContext), _context))
                .WithParameter(new TypedParameter(typeof(ILogger<Processor>), _logger))
                .WithParameter(new TypedParameter(typeof(IMapper), _mapper));

            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "TimeManager.ProcessingEngine.Processors.TaskSetProcessors")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name))
                .WithParameter(new TypedParameter(typeof(DataContext), _context))
                .WithParameter(new TypedParameter(typeof(ILogger<Processor>), _logger))
                .WithParameter(new TypedParameter(typeof(IMapper), _mapper));

            return container.Build();
        }
    }
}
