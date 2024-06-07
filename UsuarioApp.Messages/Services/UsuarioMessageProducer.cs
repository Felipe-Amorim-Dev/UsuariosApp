using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Interfaces.Messages;
using UsuariosApp.Messages.Models;
using UsuariosApp.Messages.Settings;

namespace UsuariosApp.Messages.Services
{
    public class UsuarioMessageProducer : IUsuarioMessage
    {
        public void SendMessage(string to, string subject, string body)
        {
            var model = new UsuarioMessageModel
            {
                Id = Guid.NewGuid(),
                To = to,
                Subject = subject,
                Body = body,
                CriadoEm = DateTime.Now,
            };

            var settings = new RabbitMQSettings();

            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(settings.Host)
            };

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var queue = connection.CreateModel())
                {
                    queue.QueueDeclare(
                        queue: settings.Queue,
                        durable: true,
                        autoDelete: false,
                        exclusive: false,
                        arguments: null
                    );

                    queue.BasicPublish(
                        exchange: string.Empty,
                        routingKey: settings.Queue,
                        basicProperties: null,
                        body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model))
                        );
                }
            }
        }
    }
}
