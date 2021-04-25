namespace Entities.Contracts
{
    /// <summary>
    /// IMessageBroker interface
    /// </summary>
    public interface IMessageBroker
    {
        /// <summary>
        /// SendMessageToQueue contract
        /// </summary>
        /// <param name="message"></param>
        void SendMessageToQueue(string message);
    }
}
