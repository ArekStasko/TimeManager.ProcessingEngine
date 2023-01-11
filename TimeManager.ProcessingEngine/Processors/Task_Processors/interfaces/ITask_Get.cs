using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public interface ITask_Get
    {
        public Result<ITaskRecord> Execute(int taskRecordId);
    }
}
