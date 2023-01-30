using AutoMapper;
using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors.TaskProcessors
{
    public class Task_CalculateData : Processor, ITask_CalculateData
    {
        public Task_CalculateData(DataContext context, ILogger<Processor> logger, IMapper mapper) : base(context, logger, mapper) { }

      
        public Result<ITaskRecords> Execute(int taskSetRecordId)
        {
            throw new NotImplementedException();
        }

    }
}
