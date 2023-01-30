using AutoMapper;
using LanguageExt;
using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;
using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors.TaskProcessors
{
    public class Task_Post : Processor, ITask_Post
    {
        public Task_Post(DataContext context, ILogger<Processor> logger, IMapper mapper) : base(context, logger, mapper) { }

        public Result<bool> Execute(string body)
        {
            try
            {
                TaskDTO taskDTO = JsonConvert.DeserializeObject<TaskDTO>(body);
                var taskRecord = _mapper.Map<TaskRecords>(taskDTO);
                
                _context.TaskRecords.Add(taskRecord);

                var userRecord = _context.UserRecords.Single(u => u.UserId == taskRecord.UserId);

                if (userRecord.IsNull()) return new Result<bool>(new ResultIsNullException("User ID is wrong"));
                
                userRecord.TaskCount++;
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
