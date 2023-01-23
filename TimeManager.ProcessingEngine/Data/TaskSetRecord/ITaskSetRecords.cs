using System.ComponentModel.DataAnnotations;

namespace TimeManager.ProcessingEngine.Data
{
    public interface ITaskSetRecords
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<TaskDate> TaskOccurencies { get; set; }
        public TaskDTO Task { get; set; }
    }
}
