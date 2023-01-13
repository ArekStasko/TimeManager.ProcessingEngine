using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors.TaskProcessors
{
    public interface ITask_Delete
    {
        public Result<bool> Execute(string body);
    }
}
