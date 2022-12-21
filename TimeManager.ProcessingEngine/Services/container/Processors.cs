using Autofac;
using TimeManager.ProcessingEngine.Processors;

namespace TimeManager.ProcessingEngine.Services.container
{
    public class Processors : IProcessors
    {
        private IContainer _container { get; } = ContainerConfig.CreateProcessorsContainer();

        public ITask_Delete task_Delete { get => _container.Resolve<ITask_Delete>(); }
        public ITask_Post task_Post { get => _container.Resolve<ITask_Post>(); }
        public ITask_Update task_Update { get => _container.Resolve<ITask_Update>(); }
    }
}
