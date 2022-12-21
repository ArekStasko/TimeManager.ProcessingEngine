using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors
{
    public interface ITask_Post
    {
        public Result<bool> Execute(string body);
    }
}
