using ManagerAuthorBooks.Domain.Handlers.Contracts;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Infra.Services
{
    public class RabbitMQueue : IMediatorHandler
    {
        public void Enqueue<T>(T command, string queueName)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "broker-local",
                Port = 5672,
                UserName = "testes",
                Password = "RabbitMQ2019!"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(command));

                channel.BasicPublish(exchange: "",
                                    routingKey: queueName,
                                    basicProperties: null,
                                    body: body);

            }

        }
    }
}
