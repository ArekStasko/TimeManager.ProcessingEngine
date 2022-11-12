using Microsoft.EntityFrameworkCore;

namespace TimeManager.ProcessingEngine.Data
{
    public interface IDataContext
    {
        public DbSet<ActivitySet> activitySet { get; set; }
        public DbSet<UserSet> userSet { get; set; }
    }
}
