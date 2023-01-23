using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors.TaskProcessors
{
    public class Task_Get : Processor, ITask_Get
    {
        public Task_Get(DataContext context, ILogger<Processor> logger) : base(context, logger) { }
        public Result<ITaskRecords> Execute(int taskRecordId)
        {
            throw new NotImplementedException();
        }
    }
}
