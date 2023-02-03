using System.ComponentModel.DataAnnotations;

namespace TimeManager.ProcessingEngine.Data
{
    public class TaskSetDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
        public List<TaskDate> TaskOccurencies { get; set; }
    }
    public class TaskDate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
