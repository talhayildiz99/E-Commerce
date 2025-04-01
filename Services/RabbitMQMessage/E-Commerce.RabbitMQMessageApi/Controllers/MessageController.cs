﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace E_Commerce.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",                
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk1", false, false, false, arguments: null);

            var messageContent = "Merhaba bu mesaj RabbitMQ tarafından gönderilmiştir!";

            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            channel.BasicPublish(exchange: "", routingKey:  "Kuyruk1", basicProperties: null, body: byteMessageContent);

            return Ok("Mesajınız Kuyruğa Alınmıştır'");
        }

        private static string message;

        [HttpGet]
        public IActionResult GetMessage()
        {
            var factory = new ConnectionFactory();

            factory.HostName = "localhost";

            var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, x) =>
            {
                var byteMessage = x.Body.ToArray();
                message = Encoding.UTF8.GetString(byteMessage);                
            };

            channel.BasicConsume(queue: "Kuyruk1", autoAck: false, consumer: consumer);
            if (string.IsNullOrEmpty(message))
            {
                return NoContent();
            }
            else
            {
                return Ok(message);
            }
        }
    }
}
