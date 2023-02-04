using AutoMapper;
using LanguageExt.Common;
using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors.TaskSetProcessors
{
    public class TaskSet_Update : Processor, ITaskSet_Update
    {
        public TaskSet_Update(DataContext context, ILogger<Processor> logger, IMapper mapper) : base(context, logger, mapper) {}
        public Result<bool> Execute(string body)
        {
            try
            {
                TaskSetDTO taskSetDTO = JsonConvert.DeserializeObject<TaskSetDTO>(body);
                var record = _context.TaskSetRecords.Single(tsk => tsk.TaskSetId == taskSetDTO.Id);

                record.TaskOccurencies = taskSetDTO.TaskOccurencies;

                _context.SaveChanges();

                _logger.LogInformation("Successfully updated TaskSet Record");
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError($"Stack Trace: {ex.StackTrace}");
                return new Result<bool>(ex);
            }
        }
    }
}
