using Microsoft.AspNetCore.Mvc;
using TimeManager.ProcessingEngine.Services.container;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Controllers.TaskSetRecord
{
    [Route("pe/[controller]/[action]")]
    [ApiController]
    public class TaskSetRecordController : ControllerBase, ITaskSetRecordController
    {
        private readonly IProcessors _processors;

        public TaskSetRecordController(IProcessors processors)
        {
            _processors = processors;
        }

        [HttpPost(Name = "GetTaskSetRecords")] 
        public async Task<IActionResult> GetTaskSetRecords(Request<int> request)
        {

        }
    }
}
