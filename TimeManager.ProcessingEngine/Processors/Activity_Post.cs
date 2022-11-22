namespace TimeManager.ProcessingEngine.Processors
{
    public class Activity_Post : IProcessor
    {
        public void Execute(string body)
        {
            Console.WriteLine("Post Activated");
        }
    }
}
