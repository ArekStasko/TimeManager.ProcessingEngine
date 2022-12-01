using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public class Activity_Post : IProcessor
    {
        private DataContext _context;

        public Activity_Post(DataContext context)
        {
            _context = context;
        }

        public void Execute(string body)
        {
            try
            {
                ActivityDTO activityDTO = JsonConvert.DeserializeObject<ActivityDTO>(body);

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
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
