using LanguageExt.Common;
using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors.TaskSetProcessors
{
    public class TaskSet_Update : Processor, ITaskSet_Update
    {
        public TaskSet_Update(DataContext context, ILogger<Processor> logger) : base(context, logger) {}
        public Result<bool> Execute(string body)
        {
            try
            {
                TaskSetDTO taskSetDTO = JsonConvert.DeserializeObject<TaskSetDTO>(body);
                var record = _context.TaskSetRecords.Single(tsk => tsk.Id == taskSetDTO.Id);
                _context.TaskSetRecords.Remove(record);

                TaskSetRecords taskSetRecord = new TaskSetRecords()
                {
                    Id = taskSetDTO.Id,
                    UserId = taskSetDTO.UserId,
                    TaskOccurencies = taskSetDTO.TaskOccurencies,
                    Task = taskSetDTO.Task,
                };
                _context.TaskSetRecords.Add(taskSetRecord);
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
