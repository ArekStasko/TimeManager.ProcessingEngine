using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;
using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors
{
    public class Task_Delete : Processor<ITask_Delete>, ITask_Delete
    {
        private DataContext _context;

        public Task_Delete(DataContext context)
        {
            _context = context;
        }

        public Result<bool> Execute(string body)
        {
            try
            {
                TaskDTO activityDTO = JsonConvert.DeserializeObject<TaskDTO>(body);
                var activitySet = _context.TaskRecords.Single(act => act.TaskId == activityDTO.Id);
                _context.TaskRecords.Remove(activitySet);
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
