using TimeManager.ProcessingEngine.Processors;
using TimeManager.ProcessingEngine.Processors.TaskProcessors;
using TimeManager.ProcessingEngine.Processors.TaskSetProcessors;



namespace TimeManager.ProcessingEngine.Services.container
{
    public interface IProcessors
    {
        public ITask_Delete task_Delete { get; }
        public ITask_Post task_Post { get; }
        public ITask_Update task_Update { get; }
        public ITask_CalculateData task_CalculateData { get; }
        public ITask_Get task_Get { get; }

        public ITaskSet_Delete taskSet_Delete { get; }
        public ITaskSet_Post taskSet_Post { get; }
        public ITaskSet_Update taskSet_Update { get; }
        public ITaskSet_CalculateData taskSet_CalculateData { get; }
        public ITaskSet_Get taskSet_Get { get; }

        public IUser_Create user_Create { get; }
        public IUser_GetStats user_GetStats { get; }

    }
}
