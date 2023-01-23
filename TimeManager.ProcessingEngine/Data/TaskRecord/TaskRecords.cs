using System.ComponentModel.DataAnnotations;

namespace TimeManager.ProcessingEngine.Data
{
    public class TaskRecords : ITaskRecords
    {
        [Key]
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; } = 1;
        public double Efficiency { get; set; } = 100;
        public TimeSpan ExecutionTime { get; set; }
        public TimeSpan? Delay { get; set; } = new TimeSpan(0,0,0);
    }
}
