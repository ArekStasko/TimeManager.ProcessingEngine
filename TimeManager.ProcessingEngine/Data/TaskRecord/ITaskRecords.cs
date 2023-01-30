using System.ComponentModel.DataAnnotations;

namespace TimeManager.ProcessingEngine.Data
{

    public interface ITaskRecords
    {
        [Key]
        int Id { get; set; }
        int TaskId { get; set; }
        int UserId { get; set; }
        DateTime StartDate { get; set; }
        DateTime? EndDate { get; set; }
        DateTime? Deadline { get; set; }
        int Priority { get; set; }
        double? Efficiency { get; set; }
        bool Completed { get; set; }
        
        public TimeSpan Delay();

        public TimeSpan ExecutionTime();

        public double CalculateEfficiency();
    }
}
