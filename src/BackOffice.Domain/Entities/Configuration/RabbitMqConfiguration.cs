
namespace BackOffice.Domain.Entities.Configuration;

public class RabbitMqConfiguration
{
    public string Host { get; set; }
    public string Queue { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
