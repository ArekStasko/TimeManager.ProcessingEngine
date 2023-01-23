namespace TimeManager.ProcessingEngine.Data
{
    public interface IUserRecords
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int SuccededTasks { get; set; }
        public int FailedTasks { get; set; }
        public int AverageTaskDuration { get; set; }
        public int Effectivity { get; set; }
        public int Productivity { get; set; }
        public int TaskCount { get; set; }

    }
}
