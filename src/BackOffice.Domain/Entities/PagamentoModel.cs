using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Domain.Entities;

public class PagamentoModel : BaseModel
{
    [ForeignKey("Pedido")]
    public int PedidoId { get; set; }
    public PedidoModel Pedido { get; set; }
    public decimal Valor { get; set; }
    public DateTime Vencimento { get; set; }
    public DateTime? Pagamento { get; set; }
    public decimal? ValorPago { get; set; }
}
