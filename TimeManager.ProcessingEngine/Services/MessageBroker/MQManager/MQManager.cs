using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Services.MessageBroker
{
    public class MQManager : IHostedService
    {
        private readonly DefaultObjectPool<IModel> _objectPool;
        private readonly IActivitySetProcessors _processors;

        public MQManager(IPooledObjectPolicy<IModel> objectPolicy, IActivitySetProcessors processors)
        {
            _objectPool = new DefaultObjectPool<IModel>(objectPolicy, Environment.ProcessorCount * 2);
            _processors = processors;
        } 
        

       public void Consume()
       {
            var channel = _objectPool.Get();
            MessageReceiver messageReceiver = new MessageReceiver(channel, _processors);
            string[] queues = new string[] { "entity.activity.post-queue", "entity.activity.delete-queue", "entity.activity.update-queue" };

            foreach (var queue in queues) channel.BasicConsume(queue, false, messageReceiver);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                Consume();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                return Task.CompletedTask;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
