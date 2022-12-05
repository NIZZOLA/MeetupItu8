namespace ReceptorDePedido
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ConsumerService _service;

        public Worker(ILogger<Worker> logger, ConsumerService service)
        {
            _logger = logger;
            _service = service;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //while (!stoppingToken.IsCancellationRequested)
            //{
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
             await _service.Consume();

          
            //}
        }
    }
}