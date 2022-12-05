using BackOffice.Domain.Entities;

namespace BackOffice.Infra.Sql.EntityConfig;
public class PagamentoEntityConfiguration
{
    public int PedidoId { get; set; }
    public decimal Valor { get; set; }
    public DateTime Vencimento { get; set; }
    public DateTime? Pagamento { get; set; }
    public decimal? ValorPago { get; set; }
}
