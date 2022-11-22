namespace TimeManager.ProcessingEngine.Data
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime Deadline { get; set; }
        public int UserId { get; set; }
        public int Priority { get; set; }
    }
}
