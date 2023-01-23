using Microsoft.EntityFrameworkCore;

namespace TimeManager.ProcessingEngine.Data
{
    public interface IDataContext
    {
        public DbSet<TaskRecords> TaskRecords { get; set; }
        public DbSet<TaskSetRecords> TaskSetRecords { get; set; }
        public DbSet<UserRecords> UserRecords { get; set; }
    }
}
