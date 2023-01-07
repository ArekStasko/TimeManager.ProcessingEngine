using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public class TaskSet_Delete : Processor<ITaskSet_Delete>, ITaskSet_Delete
    {
        public TaskSet_Delete(DataContext context, ILogger<ITaskSet_Delete> logger) : base(context, logger) { }

        public Result<bool> Execute(string body)
        {
            throw new NotImplementedException();
        }
    }
}
