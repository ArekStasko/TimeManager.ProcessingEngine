using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeManager.ProcessingEngine.Data
{
    public interface ITaskSetRecords
    {
        [Key]
        int Id { get; set; } 
        int UserId { get; set; }
        List<TaskDate> TaskOccurencies { get; set; }
        TaskRecords Task { get; set; }
    }
}
