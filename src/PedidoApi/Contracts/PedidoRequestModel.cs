namespace BackOffice.WebApi.Contracts;

public class PedidoRequestModel
{
    public Guid? Id { get; set; }
    public DateTime DataDaCompra { get; set; }

    public int ClienteId { get; set; }
    public ICollection<PedidoItemRequestModel>? Itens { get; set; }
    public ICollection<PagamentoRequestModel>? Pagamentos { get; set; }
}
