using LanguageExt.Common;
using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public class TaskSet_Delete : Processor, ITaskSet_Delete
    {
        public TaskSet_Delete(DataContext context, ILogger<Processor> logger) : base(context, logger) { }

        public Result<bool> Execute(string body)
        {
            try
            {
                TaskSetDTO taskDTO = JsonConvert.DeserializeObject<TaskSetDTO>(body);
                var taskRecord = _context.TaskSetRecords.Single(tsk => tsk.Id == taskDTO.Id);
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
