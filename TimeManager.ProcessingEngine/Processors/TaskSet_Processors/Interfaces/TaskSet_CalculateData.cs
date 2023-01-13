using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors.TaskSetProcessors
{
    public interface ITaskSet_CalculateData
    {
        public Result<bool> Execute(int taskSetRecordId);
    }
}
