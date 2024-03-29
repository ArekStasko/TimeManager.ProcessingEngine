﻿using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;
using TimeManager.ProcessingEngine.Data;
using TimeManager.ProcessingEngine.Services.container;
using RabbitMQ.Client.Events;
using LanguageExt.Common;
using Newtonsoft.Json.Linq;

namespace TimeManager.ProcessingEngine.Services.MessageBroker
{
    public class MQManager : IHostedService
    {
        private readonly DefaultObjectPool<IModel> _objectPool;
        private readonly IProcessors _processors;

        public MQManager(IPooledObjectPolicy<IModel> objectPolicy, IProcessors processors)
        {
            _objectPool = new DefaultObjectPool<IModel>(objectPolicy, Environment.ProcessorCount * 2);
            _processors = processors;
        } 
        
       public void Consume()
       {
            var channel = _objectPool.Get();
            string[] queues = new string[] { "entity.user.post-queue", "entity.task.post-queue", "entity.task.delete-queue", "entity.task.update-queue", "entity.taskSet.post-queue", "entity.taskSet.delete-queue", "entity.taskSet.update-queue" };
            var consumer = new EventingBasicConsumer(channel);

            foreach (var queue in queues) channel.BasicConsume(queue, false, consumer);
            
            consumer.Received += (model, ea) =>
            {
                var jsonBody = JObject.Parse(Encoding.UTF8.GetString(ea.Body.ToArray()));
                string? convertedBody = jsonBody.ToString();

                Result<bool> result = ea.RoutingKey switch
                    {
                        "task_Post" => _processors.task_Post.Execute(convertedBody),
                        "task_Update" => _processors.task_Update.Execute(convertedBody),
                        "task_Delete" => _processors.task_Delete.Execute(convertedBody),
                        "taskSet_Post" => _processors.taskSet_Post.Execute(convertedBody),
                        "taskSet_Update" => _processors.taskSet_Update.Execute(convertedBody),
                        "taskSet_Delete" => _processors.taskSet_Delete.Execute(convertedBody),
                        "user_Post" => _processors.user_Create.Execute(convertedBody),
                        _ => new Result<bool>(new Exception("Unexisting Routing Key"))
                    };
                
                var props = ea.BasicProperties;
                    var replyProps = channel.CreateBasicProperties();
                    replyProps.CorrelationId = props.CorrelationId;

                    bool response = result.Match(success =>
                    {
                        return response = success;
                    }, exception =>
                    {
                        return response = false;
                    });

                var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

                    channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };
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
