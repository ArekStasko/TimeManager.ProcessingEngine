namespace TimeManager.ProcessingEngine.Processors
{
    public class Activity_Update : IProcessor
    {
        public void Execute(string body)
        {
            Console.WriteLine("Update Activated");
        }
    }
}
