using System.ComponentModel.DataAnnotations;

namespace TimeManager.ProcessingEngine.Data
{
    public class TaskSetDTO
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<TaskDate> TaskOccurencies { get; set; }
        public TaskDTO Task { get; set; }
    }
    public class TaskDate
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
