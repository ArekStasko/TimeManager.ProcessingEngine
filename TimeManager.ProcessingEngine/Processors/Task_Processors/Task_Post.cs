using LanguageExt;
using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;
using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors.TaskProcessors
{
    public class Task_Post : Processor, ITask_Post
    {
        public Task_Post(DataContext context, ILogger<Processor> logger) : base(context, logger) { }

        public Result<bool> Execute(string body)
        {
            try
            {
                TaskDTO taskDTO = JsonConvert.DeserializeObject<TaskDTO>(body);

                TaskRecords taskRecord = new TaskRecords()
                {
                    TaskId = taskDTO.Id,
                    UserId = taskDTO.UserId,
                    StartDate = taskDTO.DateAdded
                };
                _context.TaskRecords.Add(taskRecord);
                Console.WriteLine($"FINDING USER WITH ID: {taskRecord.UserId}");

                var userRecord = _context.UserRecords.Single(u => u.UserId == taskRecord.UserId);
                Console.WriteLine("FOUND");

                if (userRecord.IsNull()) return new Result<bool>(new ResultIsNullException("User ID is wrong"));
                
                userRecord.TaskCount++;
                Console.WriteLine("ADDED");
                _context.SaveChanges();

                _logger.LogInformation("Task successfully added");
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
