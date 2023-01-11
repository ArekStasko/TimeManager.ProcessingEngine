using System.ComponentModel.DataAnnotations;

namespace TimeManager.ProcessingEngine.Data
{
    public class TaskSetRecord : ITaskSetRecord
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<TaskDate> TaskOccurencies { get; set; }
        public TaskDTO Task { get; set; }
        public int? Efficiency { get; set; }
        public int? FailedTasks { get; set; }
        public int? SuccededTasks { get; set; }
        public DateTime? AvgExecutionTime { get; set; }
    }
}
