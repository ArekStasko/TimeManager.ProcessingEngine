using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public class Processor
    {
        protected DataContext _context { get; set; }
        protected ILogger<Processor> _logger { get; set; }

        public Processor(DataContext context, ILogger<Processor> logger)
        {
            _context = context;
            _logger = logger;   
        }
    }
}
