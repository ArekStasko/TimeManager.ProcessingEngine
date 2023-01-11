
namespace TimeManager.ProcessingEngine.Data
{
    public class Request<T> : IRequest<T>
    {
        public T Data { get; set; }
        public int userId { get; set; }
    }
}