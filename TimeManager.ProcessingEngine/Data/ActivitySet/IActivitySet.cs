using System.ComponentModel.DataAnnotations;

namespace TimeManager.ProcessingEngine.Data
{

    public interface IActivitySet
    {
        [Key]
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Priority { get; set; }
    }
}
