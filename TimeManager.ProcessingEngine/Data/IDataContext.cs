using Microsoft.EntityFrameworkCore;

namespace TimeManager.ProcessingEngine.Data
{
    public interface IDataContext
    {
        public DbSet<TaskRecord> TaskRecords { get; set; }
        public DbSet<UserSet> UserRecords { get; set; }
    }
}
