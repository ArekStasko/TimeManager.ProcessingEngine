using System;
using System.Reflection;
using System.Text;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using TimeManager.ProcessingEngine.Data;
using TimeManager.ProcessingEngine.Processors;
using TimeManager.ProcessingEngine.Services.container;

namespace TimeManager.ProcessingEngine.Services.MessageBroker
{
    public class MessageReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;
        private readonly IProcessors _processors;
        public MessageReceiver(IModel channel, IProcessors processors)
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

                Result<bool> result;
                switch(routingKey)
                {
                    case "task_Post":
                        {
                            result = _processors.task_Post.Execute(convertedBody);
                            break;
                        }
                    case "task_Update":
                        {
                            result = _processors.task_Update.Execute(convertedBody);
                            break;
                        }
                    case "task_Delete":
                        {
                            result = _processors.task_Delete.Execute(convertedBody);
                            break;
                        }
                }
            }
            finally
            {
                _channel.BasicAck(deliveryTag, false);
            }

        }

    }
}
