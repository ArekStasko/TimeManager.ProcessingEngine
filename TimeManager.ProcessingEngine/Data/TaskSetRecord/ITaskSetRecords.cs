using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeManager.ProcessingEngine.Data
{
    public interface ITaskSetRecords
    {
        [Key]
        int Id { get; set; } 
        Guid TaskSetId { get; set; }
        Guid UserId { get; set; }
        Guid TaskId { get; set; }
        List<TaskDate> TaskOccurencies { get; set; }
    }
}
