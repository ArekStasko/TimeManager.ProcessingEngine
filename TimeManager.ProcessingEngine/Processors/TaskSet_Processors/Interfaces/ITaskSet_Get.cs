using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public interface ITaskSet_Get
    {
        public Result<ITaskSetRecord> Execute(int taskSetRecordId);
    }
}
