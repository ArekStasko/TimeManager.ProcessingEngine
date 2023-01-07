using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public class TaskSet_Update : Processor, ITaskSet_Update
    {
        public TaskSet_Update(DataContext context, ILogger<Processor> logger) : base(context, logger) {}
        public Result<bool> Execute(string body)
        {
            throw new NotImplementedException();
        }
    }
}
