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
                ActivityDTO activityDTO = JsonConvert.DeserializeObject<ActivityDTO>(body);
                var actSet = _context.activitySet.Single(act => act.ActivityId == activityDTO.Id);
                _context.activitySet.Remove(actSet);

                ActivitySet activitySet = new ActivitySet()
                {
                    ActivityId = activityDTO.Id,
                    UserId = activityDTO.UserId,
                    StartDate = activityDTO.DateAdded
                };
                _context.activitySet.Add(activitySet);
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
