using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Microsoft.AspNetCore.Mvc;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace publisher.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {

        private readonly IConnection _connection;
        public ReportController()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();

        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            using (IModel channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: "getAddresses", durable: false, exclusive: false, autoDelete: false, arguments: null);

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;


                channel.ConfirmSelect();

                var body = Encoding.UTF8.GetBytes("getAddresses");

                channel.BasicPublish(exchange: "",
                                     routingKey: "getAddresses",
                                     basicProperties: properties,
                                     body: body);

                channel.WaitForConfirmsOrDie();

                channel.BasicAcks += (sender, eventArgs) =>
                {
                    Console.WriteLine("Sent RabbitMQ");
                    //implement ack handle
                };
                channel.ConfirmSelect();

            }
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            using (IModel channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: "getAddresses", durable: false, exclusive: false, autoDelete: false, arguments: null);

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;


                channel.ConfirmSelect();

                var body = Encoding.UTF8.GetBytes("getAddresses");

                channel.BasicPublish(exchange: "",
                                     routingKey: "getAddresses",
                                     basicProperties: properties,
                                     body: body);

                channel.WaitForConfirmsOrDie();

                channel.BasicAcks += (sender, eventArgs) =>
                {
                    Console.WriteLine("Sent RabbitMQ");
                    //implement ack handle
                };
                channel.ConfirmSelect();

            }
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

