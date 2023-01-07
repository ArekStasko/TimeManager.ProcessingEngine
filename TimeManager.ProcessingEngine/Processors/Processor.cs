using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public class Processor<T>
    {
        protected DataContext _context { get; set; }
        protected ILogger<T> _logger { get; set; }

        public Processor(DataContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;   
        }
    }
}
