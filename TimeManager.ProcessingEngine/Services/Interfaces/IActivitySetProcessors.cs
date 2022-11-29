namespace TimeManager.ProcessingEngine.Services
{
    public interface IActivitySetProcessors
    {
        public void Activity_Delete(string body);
        public void Activity_Update(string body);
        public void Activity_Post(string body);
    }
}
