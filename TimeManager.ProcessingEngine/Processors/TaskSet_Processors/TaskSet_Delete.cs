using AutoMapper;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors.TaskSetProcessors
{
    public class TaskSet_Delete : Processor, ITaskSet_Delete
    {
        public TaskSet_Delete(DataContext context, ILogger<Processor> logger, IMapper mapper) : base(context, logger, mapper) { }

        public Result<bool> Execute(string body)
        {
            try
            {
                TaskSetDTO taskDTO = JsonConvert.DeserializeObject<TaskSetDTO>(body);
                var toDelete = _context.TaskSetRecords.OrderBy(e => e.Id).Include(e => e.TaskOccurencies);
                var taskRecord = toDelete.Single(tsk => tsk.TaskSetId == taskDTO.Id);
                _context.TaskSetRecords.Remove(taskRecord);
                _context.SaveChanges();
                _logger.LogInformation("Successfully removed TaskSet Record");
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
