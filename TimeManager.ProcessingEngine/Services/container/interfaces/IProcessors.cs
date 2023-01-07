using TimeManager.ProcessingEngine.Processors;


namespace TimeManager.ProcessingEngine.Services.container
{
    public interface IProcessors
    {
        public ITask_Delete task_Delete { get; }
        public ITask_Post task_Post { get; }
        public ITask_Update task_Update { get; }
        public ITaskSet_Delete taskSet_Delete { get; }
        public ITaskSet_Post taskSet_Post { get; }
        public ITaskSet_Update taskSet_Update { get; }
    }
}
