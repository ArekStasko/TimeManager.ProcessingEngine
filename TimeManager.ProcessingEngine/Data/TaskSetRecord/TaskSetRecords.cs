using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeManager.ProcessingEngine.Data
{
    public class TaskSetRecords : ITaskSetRecords
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<TaskDate> TaskOccurencies { get; set; }
        public TaskRecords Task { get; set; }
        public int? Efficiency { get; set; }
        public int? FailedTasks { get; set; }
        public int? SuccededTasks { get; set; }
        public DateTime? AvgExecutionTime { get; set; }
    }
}
