using Microsoft.AspNetCore.Mvc;
using TimeManager.ProcessingEngine.Data;
using TimeManager.ProcessingEngine.Services.container;

namespace TimeManager.ProcessingEngine.Controllers.TaskRecord
{
    [Route("pe/[controller]/[action]")]
    [ApiController]
    public class TaskRecordController : ControllerBase, ITaskRecordController
    {
        private readonly IProcessors _processors;

        public TaskRecordController(IProcessors processors)
        {
            _processors = processors;
        }

        [HttpPost(Name = "GetTaskRecords")]
        public async Task<IActionResult> GetTaskRecords(Request<int> request)
        {

        }
    }
}
