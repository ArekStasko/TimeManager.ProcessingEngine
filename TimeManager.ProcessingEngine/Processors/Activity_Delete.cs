namespace TimeManager.ProcessingEngine.Processors
{
    public class Activity_Delete : IProcessor
    {
        public void Execute(string body)
        {
            Console.WriteLine("Delete activated");
        }
    }
}
