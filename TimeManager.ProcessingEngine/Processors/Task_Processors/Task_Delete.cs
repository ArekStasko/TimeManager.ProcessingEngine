using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;
using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors
{
    public class Task_Delete : Processor, ITask_Delete
    {
        public Task_Delete(DataContext context, ILogger<Processor> logger) : base(context, logger) { }

        public Result<bool> Execute(string body)
        {
            try
            {
                TaskDTO taskDTO = JsonConvert.DeserializeObject<TaskDTO>(body);
                var taskRecord = _context.TaskRecords.Single(act => act.TaskId == taskDTO.Id);
                _context.TaskRecords.Remove(taskRecord);
                _context.SaveChanges();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }
    }
}
