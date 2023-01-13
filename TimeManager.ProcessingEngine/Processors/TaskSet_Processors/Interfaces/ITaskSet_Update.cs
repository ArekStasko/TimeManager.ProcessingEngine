using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors.TaskSetProcessors
{
    public interface ITaskSet_Update
    {
        public Result<bool> Execute(string body);
    }
}
