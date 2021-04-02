namespace Entities.Contracts
{
    /// <summary>
    /// IMessageBroker interface
    /// </summary>
    public interface IMessageBroker
    {
        /// <summary>
        /// SendMessageToQueu contract
        /// </summary>
        /// <param name="message"></param>
        void SendMessageToQueu(string message);
    }
}
