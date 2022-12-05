using BackOffice.Infra.Sql.Data;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ReceptorDePedido;

public class ConsumerService : IConsumerService
{
    private readonly ILogger _logger;
    private BackOfficeContext _context;
    //public ConsumerService(ILogger<ConsumerService> logger, IServiceProvider serviceProvider)
    //{
    //    _logger = logger;
    //    var scope = serviceProvider.CreateScope();
    //    _context = scope.ServiceProvider.GetRequiredService<BackOfficeContext>();
    //}
    public ConsumerService(ILogger<ConsumerService> logger)
    {
        _logger = logger;
    }

    private void Consumer_Received(object sender, BasicDeliverEventArgs e)
    {
        _logger.LogInformation(
            $"[Nova mensagem | {DateTime.Now:yyyy-MM-dd HH:mm:ss}] " +
            Encoding.UTF8.GetString(e.Body.ToArray()));

        var texto = Encoding.UTF8.GetString(e.Body.ToArray());
        File.WriteAllText("mensagem.txt", texto );

        //try
        //{

        //    var pedido = JsonSerializer.Deserialize<PedidoModel>(Encoding.UTF8.GetString(e.Body.ToArray()));
        //    File.WriteAllText("mensagem2.txt", texto);

        //    _context.Add(pedido);
        //    _context.SaveChanges();
        //}
        //catch (Exception error)
        //{
        //    _logger.LogError(error.ToString());
        //    throw;
        //}

    }

    public async Task Consume()
    {
        _logger.LogInformation("Connecting into RabbitMq");

        var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
        using (var connection = factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ECommerceNovoPedido",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                //channel.BasicQos(0, 2, false);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += Consumer_Received;
                channel.BasicConsume(queue: "ECommerceNovoPedido",
                    autoAck: true,
                    consumer: consumer);
            }
        }
    }
}
