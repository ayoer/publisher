using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace publisher
{
    public class Startup
    {


        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        private readonly IConnection _connection;
        public Startup()
        {

            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();


            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: "report",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);





                };
                channel.BasicConsume(queue: "report",
                                     autoAck: true,
                                     consumer: consumer);

               
            }

        }
    }
}

