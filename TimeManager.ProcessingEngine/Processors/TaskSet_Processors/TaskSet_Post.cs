using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public class TaskSet_Post : Processor, ITaskSet_Post
    {
        public TaskSet_Post(DataContext context, ILogger<Processor> logger) : base(context, logger) {}

        public Result<bool> Execute(string body)
        {
            throw new NotImplementedException();
        }
    }
}
