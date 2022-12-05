using BackOffice.WebApi.Contracts;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace PedidoApi;

public class QueueService
{
    public void Publish(PedidoRequestModel pedido)
    {
        var factory = new ConnectionFactory();
        factory.UserName = "guest";
        factory.Password = "guest";
        factory.HostName = "192.168.15.4";

        string exchangeName = "Ecommerce";

        using (var conn = factory.CreateConnection())
        using (var channel = conn.CreateModel())
        {
            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, true);
            //channel.QueueDeclare(queueName, true, false, false, null);

            var input = JsonSerializer.Serialize(pedido);
            var messageBodyBytes = Encoding.UTF8.GetBytes(input);

            channel.BasicPublish(exchangeName,
                                 "novopedido",
                                 null,
                                 messageBodyBytes);
        }
    }
}
