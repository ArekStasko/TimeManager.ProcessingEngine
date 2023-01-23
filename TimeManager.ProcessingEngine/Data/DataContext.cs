using Microsoft.EntityFrameworkCore;

namespace TimeManager.ProcessingEngine.Data
{
    public class DataContext : DbContext, IDataContext
    {
        private readonly string _connectionString;

        public DataContext() { }
        public DataContext(string connectionString) => _connectionString = connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public virtual DbSet<TaskRecords> TaskRecords { get; set; }
        public virtual DbSet<TaskSetRecords> TaskSetRecords { get; set; }
        public DbSet<UserRecords> UserRecords { get; set; }
    }
}
