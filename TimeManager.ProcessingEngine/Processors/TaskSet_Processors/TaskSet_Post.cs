using AutoMapper;
using LanguageExt.Common;
using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors.TaskSetProcessors
{
    public class TaskSet_Post : Processor, ITaskSet_Post
    {
        public TaskSet_Post(DataContext context, ILogger<Processor> logger, IMapper mapper) : base(context, logger, mapper) {}

        public Result<bool> Execute(string body)
        {
            try
            {
                TaskSetDTO taskSetDTO = JsonConvert.DeserializeObject<TaskSetDTO>(body);
                var taskSetRecord = _mapper.Map<TaskSetRecords>(taskSetDTO);
                
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
