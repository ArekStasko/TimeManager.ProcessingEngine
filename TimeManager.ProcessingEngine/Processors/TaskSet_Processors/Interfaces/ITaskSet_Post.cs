using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors.TaskSet_Processors.Interfaces
{
    public interface ITaskSet_Post
    {
        public Result<bool> Execute(string body);
    }
}
