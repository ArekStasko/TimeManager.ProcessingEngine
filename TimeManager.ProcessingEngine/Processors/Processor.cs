using AutoMapper;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public class Processor
    {
        protected DataContext _context { get; }
        protected ILogger<Processor> _logger { get; }
        protected  IMapper _mapper { get; }

        public Processor(DataContext context, ILogger<Processor> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
    }
}
