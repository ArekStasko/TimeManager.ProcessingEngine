using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Services.MessageBroker
{
    public class MQManager : IMQManager
    {
        private readonly DefaultObjectPool<IModel> _objectPool;

        public MQManager(IPooledObjectPolicy<IModel> objectPolicy)
        {
            _objectPool = new DefaultObjectPool<IModel>(objectPolicy, Environment.ProcessorCount * 2);
        }

       public void Consume(IActivitySetProcessors processors)
       {
            var channel = _objectPool.Get();
            MessageReceiver messageReceiver = new MessageReceiver(channel, processors);
            string[] queues = new string[] { "entity.activity.post-queue", "entity.activity.delete-queue", "entity.activity.update-queue" };

            foreach (var queue in queues) channel.BasicConsume(queue, false, messageReceiver);
        }
    }
}
