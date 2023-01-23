using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors.TaskProcessors
{
    public interface ITask_CalculateData
    {
        public Result<ITaskRecords> Execute(int taskRecordId);
    }
}
