namespace TimeManager.ProcessingEngine.Services
{
    public interface IActivitySetProcessors
    {
        public void Delete(string body);
        public void Update(string body);
        public void Post(string body);
    }
}
