using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using publisher.Models;
using publisher.Models.Report;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace publisher.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {

        private readonly IConnection _connection;
        private readonly ApplicationDbContext _context;
        public ReportController(ApplicationDbContext context)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _context = context;

        }
        // GET: api/values
        [HttpGet]
        public ActionResult<List<ReportModel>> GetAll()
        {
            var info = _context.ReportModels.ToList();

            if (info != null)
            {
                return info;
            }

            return NotFound();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

            using (IModel channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: "report", durable: false, exclusive: false, autoDelete: false, arguments: null);

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;


                channel.ConfirmSelect();

                var body = Encoding.UTF8.GetBytes("report");

                channel.BasicPublish(exchange: "",
                                     routingKey: "report",
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

