using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public class Activity_Delete : IProcessor
    {
        private DataContext _context;

        public Activity_Delete(DataContext context)
        {
            _context = context;
        }

        public void Execute(string body)
        {
            try
            {
                ActivityDTO activityDTO = JsonConvert.DeserializeObject<ActivityDTO>(body);
                var activitySet = _context.activitySet.Single(act => act.ActivityId == activityDTO.Id);
                _context.activitySet.Remove(activitySet);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
