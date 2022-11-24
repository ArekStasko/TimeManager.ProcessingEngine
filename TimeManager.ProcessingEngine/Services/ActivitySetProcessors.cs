using TimeManager.ProcessingEngine.Data;
using TimeManager.ProcessingEngine.Processors;

namespace TimeManager.ProcessingEngine.Services
{
    public class ActivitySetProcessors : IActivitySetProcessors
    {
        private readonly DataContext _context;
        public ActivitySetProcessors(DataContext context) => _context = context;

        public void Delete(string body)
        {
            IProcessor processor = new Activity_Delete(_context);
            processor.Execute(body);
        }

        public void Post(string body)
        {
            IProcessor processor = new Activity_Post(_context);
            processor.Execute(body);
        }

        public void Update(string body)
        {
            IProcessor processor = new Activity_Update(_context);
            processor.Execute(body);
        }
    }
}
