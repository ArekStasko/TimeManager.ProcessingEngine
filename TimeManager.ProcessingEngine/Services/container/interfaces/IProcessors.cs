using TimeManager.ProcessingEngine.Processors;


namespace TimeManager.ProcessingEngine.Services.container
{
    public interface IProcessors
    {
        public ITask_Delete task_Delete { get; }
        public ITask_Post task_Post { get; }
        public ITask_Update task_Update { get; }
    }
}
