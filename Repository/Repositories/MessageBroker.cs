using System.Text;

using Entities.Contracts;

using RabbitMQ.Client;

namespace Repository.Repositories
{
    /// <summary>
    /// MessageBroker class reposinble for sending messages to the queue
    /// </summary>
    public class MessageBroker : IMessageBroker
    {
        /// <summary>
        /// SendMessageToQueue method
        /// </summary>
        /// <param name="message"></param>
        public void SendMessageToQueue(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "chargingStations",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                routingKey: "chargingStations",
                basicProperties: null,
                body: body);
        }
    }
}
