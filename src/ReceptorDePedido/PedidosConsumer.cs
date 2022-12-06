using BackOffice.Domain.Entities;
using BackOffice.Domain.Entities.Configuration;
using BackOffice.Infra.Sql.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace ReceptorDePedido;

public class PedidosConsumer : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly ILogger _logger;
    private readonly RabbitMqConfiguration _config;
    private readonly BackOfficeContext _context;
    public PedidosConsumer(ILogger<PedidosConsumer> logger, IOptions<RabbitMqConfiguration> options,
        IServiceProvider serviceProvider)
    {
        _config = options.Value;
        _logger = logger;

        var scope = serviceProvider.CreateScope();
        _context = scope.ServiceProvider.GetRequiredService<BackOfficeContext>();

        _logger.LogInformation("Iniciando leitura do Queue:" + _config.Queue);
        var factory = new ConnectionFactory() { HostName = _config.Host, UserName = _config.Username, Password = _config.Password };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: _config.Queue,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += Consumer_Received;

        _channel.BasicConsume(_config.Queue,
            autoAck: false,
            consumer: consumer);
        
        return Task.CompletedTask;
    }

    private void Consumer_Received(object sender, BasicDeliverEventArgs e)
    {
        _logger.LogInformation( $"[Nova mensagem | {DateTime.Now:yyyy-MM-dd HH:mm:ss}] " + Encoding.UTF8.GetString(e.Body.ToArray()));

        var texto = Encoding.UTF8.GetString(e.Body.ToArray());
        //File.WriteAllText("mensagem.txt", texto);
        try
        {
            var pedido = JsonSerializer.Deserialize<PedidoModel>(texto);

            _context.Add(pedido);
            _context.SaveChanges();
        }
        catch (Exception error)
        {
            _logger.LogError("Deserialize message error:" + error.Message.ToString());
        }
        

        _channel.BasicAck(e.DeliveryTag, false);
    }
}