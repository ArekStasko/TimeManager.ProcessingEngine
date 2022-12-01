using System;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
                var jsonBody = JObject.Parse(Encoding.UTF8.GetString(body.ToArray()));
                string? convertedBody = jsonBody["Result"]["Value"].ToString();

                if (convertedBody == null) throw new Exception("Message Body has wrong format");

                MethodInfo? processorCall = _processors.GetType().GetMethod(routingKey);
                if (processorCall == null) throw new Exception("Processor call error");

                processorCall.Invoke(_processors, new object[] { convertedBody });
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
