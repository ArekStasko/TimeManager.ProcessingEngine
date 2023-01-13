using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors.TaskProcessors
{
    public interface ITask_Post
    {
        public Result<bool> Execute(string body);
    }
}
