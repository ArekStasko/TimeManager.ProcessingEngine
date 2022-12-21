using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;
using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors
{
    public class Task_Post : Processor<ITask_Post>, ITask_Post
    {
        private DataContext _context;

        public Task_Post(DataContext context)
        {
            _context = context;
        }

        public Result<bool> Execute(string body)
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

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Result<bool>(ex);
            }
        }
    }
}
