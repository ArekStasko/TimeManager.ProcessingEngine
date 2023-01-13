using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors.TaskSetProcessors
{
    public interface ITaskSet_Delete
    {
        public Result<bool> Execute(string body);
    }
}
