namespace TimeManager.ProcessingEngine.Services.MessageBroker
{
    public interface IMQManager
    {
        void Publish<T>(T message, string exchangeName, string exchangeType, string routeKey) where T : class;
    }
}
