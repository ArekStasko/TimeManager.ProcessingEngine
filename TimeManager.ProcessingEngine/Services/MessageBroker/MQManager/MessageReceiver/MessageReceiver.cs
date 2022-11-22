using System;
using System.Reflection;
using System.Text;
using RabbitMQ.Client;
using TimeManager.ProcessingEngine.Processors;

namespace TimeManager.ProcessingEngine.Services.MessageBroker
{
    public class MessageReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;
        public MessageReceiver(IModel channel) => _channel = channel;

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, ReadOnlyMemory<byte> body)
        {
            try
            {
                string convertedBody = Encoding.UTF8.GetString(body.ToArray());
                Assembly assem = Assembly.GetExecutingAssembly();
                IProcessor processor = (IProcessor)assem.CreateInstance($"TimeManager.ProcessingEngine.Processors.{routingKey}");
                processor.Execute(convertedBody);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _channel.BasicAck(deliveryTag, false);
            }

        }

    }
}
