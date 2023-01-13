using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors.TaskProcessors
{
    public interface ITask_Update
    {
        public Result<bool> Execute(string body);
    }
}
