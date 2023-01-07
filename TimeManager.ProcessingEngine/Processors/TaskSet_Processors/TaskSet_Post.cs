using LanguageExt.Common;
using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public class TaskSet_Post : Processor, ITaskSet_Post
    {
        public TaskSet_Post(DataContext context, ILogger<Processor> logger) : base(context, logger) {}

        public Result<bool> Execute(string body)
        {
            try
            {
                TaskSetDTO taskSetDTO = JsonConvert.DeserializeObject<TaskSetDTO>(body);

                TaskSetRecord taskSetRecord = new TaskSetRecord()
                {
                    Id = taskSetDTO.Id,
                    UserId = taskSetDTO.UserId,
                    TaskOccurencies = taskSetDTO.TaskOccurencies,
                    Task = taskSetDTO.Task,
                };
                _context.TaskSetRecords.Add(taskSetRecord);
                _context.SaveChanges();

                _logger.LogInformation($"Successfully added TaskSet Record");
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError($"Stack trace: {ex.StackTrace}");
                return new Result<bool>(ex);
            }
        }
    }
}
