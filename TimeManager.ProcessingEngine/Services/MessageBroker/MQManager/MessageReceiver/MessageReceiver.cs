using System;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using TimeManager.ProcessingEngine.Data;
using TimeManager.ProcessingEngine.Processors;

namespace TimeManager.ProcessingEngine.Services.MessageBroker
{
    public class MessageReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;
        private readonly IActivitySetProcessors _processors;
        public MessageReceiver(IModel channel, IActivitySetProcessors processors)
        {
            _channel = channel;
            _processors = processors;
        } 

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, ReadOnlyMemory<byte> body)
        {
            try
            {
                    string convertedBody = Encoding.UTF8.GetString(body.ToArray());
                //IProcessor processor = (IProcessor)assem.CreateInstance($"TimeManager.ProcessingEngine.Processors.{routingKey}");
                //processor.Execute(convertedBody);
                _processors.Activity_Post(convertedBody);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                _channel.BasicAck(deliveryTag, false);
            }

        }

    }
}
