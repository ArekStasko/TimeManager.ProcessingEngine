using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LanguageExt;

namespace TimeManager.ProcessingEngine.Data
{
    public class TaskRecords : ITaskRecords
    {
        private double? _executionTime;
        private double? _delay;
        
        [Key]
        public int Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Deadline { get; set; }
        public int Priority { get; set; } = 1;
        public double? Efficiency { get; set; } = 100;
        public bool Completed { get; set; }


        public TimeSpan Delay() => (EndDate - Deadline) ?? new TimeSpan(0);

        public TimeSpan ExecutionTime() => (EndDate - StartDate) ?? new TimeSpan(0);
        
        public double CalculateEfficiency()
        {
            var delay = Delay();
            var executionTime = ExecutionTime();
            
            double delayCount = delay.Hours * Priority + delay.Minutes * (Priority * 0.1) + delay.Seconds  * (Priority * 0.01);
            double executionCount = executionTime.Hours * Priority + executionTime.Minutes * (Priority * 0.1) + executionTime.Seconds * (Priority * 0.01);
            
            double efficiency = (
                Delay().Ticks > 0
                ? Efficiency - (delayCount + executionCount)
                : Efficiency + (delayCount + executionCount)
                ) ?? 100;

            return efficiency;
        }
        
    }
}
