using System.Text;

using Entities.Contracts;
using RabbitMQ.Client;

namespace Repository.Repositories
{
    public class MessageBroker : IMessageBroker
    {
        public void SendMessageToQueu(string message)
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
