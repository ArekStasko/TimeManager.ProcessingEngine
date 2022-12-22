using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;
using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors
{
    public class Task_Update : Processor<ITask_Update>, ITask_Update
    {
        private DataContext _context;

        public Task_Update(DataContext context)
        {
            _context = context;
        }

        public Result<bool> Execute(string body)
        {
            try
            {
                TaskDTO activityDTO = JsonConvert.DeserializeObject<TaskDTO>(body);
                var actSet = _context.TaskRecords.Single(act => act.TaskId == activityDTO.Id);
                _context.TaskRecords.Remove(actSet);

                TaskRecord activitySet = new TaskRecord()
                {
                    TaskId = activityDTO.Id,
                    UserId = activityDTO.UserId,
                    StartDate = activityDTO.DateAdded
                };
                _context.TaskRecords.Add(activitySet);
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
