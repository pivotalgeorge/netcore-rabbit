using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace netcore_rabbit.Controllers
{
    [Route("api/[controller]")]
    public class RabbitDriverController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"rabbit", "driver"};
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Publish();
        }

        
        private void Publish()
        {
            ConnectionFactory factory = new ConnectionFactory();
            // default guest:guest at localhost/
            factory.HostName = "localhost";
//            factory.UserName = "guest";
//            factory.Password = "guest";
//            factory.VirtualHost = vhost;
            
            var connection = factory.CreateConnection();
            
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                string message = "hi";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: "hello",
                    basicProperties: null,
                    body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
            

        }
        
    }
}