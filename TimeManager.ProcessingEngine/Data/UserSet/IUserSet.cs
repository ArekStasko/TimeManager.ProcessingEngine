using System.ComponentModel.DataAnnotations;

namespace TimeManager.ProcessingEngine.Data
{
    public interface IUserSet
    {
        [Key]
        public int UserId { get; set; }
        public int ActivitiesDone { get; set; }
        public int ActivitiesDoneWithDelay { get; set; }
        public int ActivitiesDoneEarlier { get; set; }
        public int Performance { get; set; }
        public int Productivity { get; set; }
    }
}
