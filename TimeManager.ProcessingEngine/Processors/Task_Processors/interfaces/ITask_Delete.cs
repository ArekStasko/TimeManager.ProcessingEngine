using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors
{
    public interface ITask_Delete
    {
        public Result<bool> Execute(string body);
    }
}
