using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;
using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors
{
    public class Task_Update : Processor, ITask_Update
    {

        public Task_Update(DataContext context, ILogger<Processor> logger) : base(context, logger) { }

        public Result<bool> Execute(string body)
        {
            try
            {
                TaskDTO taskDTO = JsonConvert.DeserializeObject<TaskDTO>(body);
                var record = _context.TaskRecords.Single(act => act.TaskId == taskDTO.Id);
                _context.TaskRecords.Remove(record);

                TaskRecord taskRecord = new TaskRecord()
                {
                    TaskId = taskDTO.Id,
                    UserId = taskDTO.UserId,
                    StartDate = taskDTO.DateAdded
                };
                _context.TaskRecords.Add(taskRecord);
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
