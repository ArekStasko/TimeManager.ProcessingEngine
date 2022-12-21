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
                ActivityDTO activityDTO = JsonConvert.DeserializeObject<ActivityDTO>(body);
                var activitySet = _context.activitySet.Single(act => act.ActivityId == activityDTO.Id);
                _context.activitySet.Remove(activitySet);
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
