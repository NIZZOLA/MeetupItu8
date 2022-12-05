
namespace BackOffice.WebApi.Contracts;

public class PedidoItemRequestModel
{
    public int ProdutoId { get; set; }
    public decimal Quantidade { get; set; }
    public decimal Valor { get; set; }
}