namespace Entities.Contracts
{
    public interface IMessageBroker
    {
        void SendMessageToQueu(string message);
    }
}
