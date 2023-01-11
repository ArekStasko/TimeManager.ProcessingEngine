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
            var processor = _processors.taskSet_Get;
            if (processor == null) throw new ArgumentNullException(nameof(processor));

            var result = processor.Execute(request.Data);

            return result.Match<IActionResult>(taskRecord =>
            {
                return CreatedAtAction(nameof(GetTaskSetRecords), taskRecord);
            }, exception =>
            {
                return BadRequest(exception);
            });
        }
    }
}
