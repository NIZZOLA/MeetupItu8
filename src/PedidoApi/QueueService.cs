using BackOffice.Domain.Entities.Configuration;
using BackOffice.WebApi.Contracts;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace PedidoApi;

public class QueueService
{
    private readonly RabbitMqConfiguration _config;
    public QueueService(IOptions<RabbitMqConfiguration> options)
    {
        _config = options.Value;
    }

    public void Publish(PedidoRequestModel pedido)
    {
        var factory = new ConnectionFactory() { HostName = _config.Host, UserName = _config.Username, Password = _config.Password };
       
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
