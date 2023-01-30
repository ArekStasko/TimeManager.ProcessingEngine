using AutoMapper;
using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors.TaskSetProcessors
{
    public class TaskSet_Get : Processor, ITaskSet_Get
    {
        public TaskSet_Get(DataContext context, ILogger<Processor> logger, IMapper mapper) : base(context, logger, mapper) { }
        public Result<ITaskSetRecords> Execute(int taskSetRecordId)
        {
            throw new NotImplementedException();
        }
    }
}
