using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors.TaskSetProcessors
{
    public interface ITaskSet_Get
    {
        public Result<ITaskSetRecords> Execute(int taskSetRecordId);
    }
}
