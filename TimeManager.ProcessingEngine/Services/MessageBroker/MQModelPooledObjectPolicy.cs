using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;

namespace TimeManager.ProcessingEngine.Services.MessageBroker
{
    public class MQModelPooledObjectPolicy : IPooledObjectPolicy<IModel>
    {
        private readonly IConnection _connection;

        public MQModelPooledObjectPolicy() => _connection = GetConnection();


        private IConnection GetConnection()
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            factory.Ssl.Enabled = false;
            return factory.CreateConnection();
        }

        public IModel Create()
        {
            return _connection.CreateModel();
        }

        public bool Return(IModel obj)
        {
            if (obj.IsOpen) return true;

            obj.Dispose();
            return false;
        }
    }
}
