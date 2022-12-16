using BackOffice.Domain.Entities.Configuration;
using BackOffice.Infra.Sql.Data;
using Microsoft.EntityFrameworkCore;
using ReceptorDePedido;
//using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        var template = "[{Timestamp:yyyy-MM-dd HH:mm:ss.ffff}][{Level}] - Pedidos - {Message}{NewLine}{Exception}";
        
        services.Configure<RabbitMqConfiguration>(configuration.GetSection("RabbitMqConfig"));

        //Log.Logger = new LoggerConfiguration()
        //                .ReadFrom.Configuration(configuration)
        //                .WriteTo.Console(outputTemplate: template)
        //                //.WriteTo.File(fileName, outputTemplate: template)
        //                .CreateLogger();

        services.AddDbContext<BackOfficeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PedidosBackOffice")));

        services.AddHostedService<PedidosConsumer>();
    })
    //.UseSerilog()
    .Build();

host.Run();
