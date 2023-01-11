using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public interface ITask_CalculateData
    {
        public Result<bool> Execute(int taskRecordId);
    }
}
