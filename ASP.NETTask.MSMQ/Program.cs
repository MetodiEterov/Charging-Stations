namespace ASP.NETTask.MSMQ
{
    using System;
    using System.Text;
    using System.Threading;

    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    /// <summary>
    /// Represents a message broker
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        private static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            const string queueName = "chargingStations";
            var rabbitMqConnection = factory.CreateConnection();
            var rabbitMqChannel = rabbitMqConnection.CreateModel();

            rabbitMqChannel.QueueDeclare(queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            rabbitMqChannel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            var messageCount = Convert.ToInt16(rabbitMqChannel.MessageCount(queueName));
            var consumer = new EventingBasicConsumer(rabbitMqChannel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                messageCount++;
                rabbitMqChannel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                Thread.Sleep(1000);
            };

            rabbitMqChannel.BasicConsume(queue: queueName,
                autoAck: false,
                consumer: consumer);

            Thread.Sleep(1000 * messageCount);
        }
    }
}
