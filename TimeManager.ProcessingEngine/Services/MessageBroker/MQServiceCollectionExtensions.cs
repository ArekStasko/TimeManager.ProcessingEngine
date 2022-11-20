using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;

namespace TimeManager.ProcessingEngine.Services.MessageBroker
{
    public static class MQServiceCollectionExtensions
    {
        public static IServiceCollection AddMQ(this IServiceCollection services)
        {
            services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
            services.AddSingleton<IPooledObjectPolicy<IModel>, MQModelPooledObjectPolicy>();

            services.AddSingleton<IMQManager, MQManager>();

            return services;
        }
    }
}
