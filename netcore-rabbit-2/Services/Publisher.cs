using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Rubicon.Cms.Publisher.Services {
	public class Publisher {

		private IConnectionFactory _factory;
		private IPersister _persister;

		public Publisher (IPersister persister) {
			_persister = persister;
			//string username, string password, string hostName, string vhost = "/"
			//var factory = new ConnectionFactory () {
			//	HostName = hostName,
			//	UserName = username,
			//	Password = password,
			//	VirtualHost = vhost
			//};
		}


		public void Publish (string content) {
			if (content == null)
				throw new ArgumentNullException (nameof (content), "Cannot be null.");

			//_persister.Persist (content);

			try {
				using (var connection = _factory.CreateConnection ()) {
					using (var channel = connection.CreateModel ()) {
						channel.QueueDeclare (queue: "hello",
							durable: false,
							exclusive: false,
							autoDelete: false,
							arguments: null);

						string message = "hi";
						var body = Encoding.UTF8.GetBytes (message);

						channel.BasicPublish (exchange: "",
							routingKey: "hello",
							basicProperties: null,
							body: body);
						Console.WriteLine (" [x] Sent {0}", message);
					}
				}
			} catch {

			}
		}

	}
}
