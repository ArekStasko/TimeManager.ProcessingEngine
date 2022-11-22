using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public class Activity_Update : IProcessor
    {
        private DataContext _context;

        public Activity_Update(DataContext context)
        {
            _context = context;
        }

        public void Execute(string body)
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

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
