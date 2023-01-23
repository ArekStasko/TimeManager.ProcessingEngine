namespace TimeManager.ProcessingEngine.Data
{
    public class UserRecords : IUserRecords
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int SuccededTasks { get; set; } = 0;
        public int FailedTasks { get; set; } = 0;
        public int AverageTaskDuration { get; set; } = 0;
        public int Effectivity { get; set; } = 0;
        public int Productivity { get; set; } = 0;
        public int TaskCount { get; set; } = 0;
    }
}
