using System.ComponentModel.DataAnnotations;

namespace TimeManager.ProcessingEngine.Data
{

    public interface ITaskRecord
    {
        [Key]
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
        public double Efficiency { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public TimeSpan? Delay { get; set; }
    }
}
