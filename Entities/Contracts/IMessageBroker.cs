namespace Entities.Contracts
{
    public interface IMessageBroker
    {
        void SendMessageToQueue(string message);
    }
}
