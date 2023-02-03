using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeManager.ProcessingEngine.Data
{
    public class TaskSetRecords : ITaskSetRecords
    {
        [Key]
        public int Id { get; set; }
        public Guid TaskSetId { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
        public List<TaskDate> TaskOccurencies { get; set; }
        public int? Efficiency { get; set; }
        public int? FailedTasks { get; set; }
        public int? SuccededTasks { get; set; }
        public DateTime? AvgExecutionTime { get; set; }
    }
}
