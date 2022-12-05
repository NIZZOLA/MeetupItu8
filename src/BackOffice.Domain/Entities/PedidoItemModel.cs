using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Domain.Entities;

public class PedidoItemModel : BaseModel
{
    [ForeignKey("Pedido")]
    public int PedidoId { get; set; }
    public PedidoModel? Pedido { get; set; }
    
    [ForeignKey("Produto")]
    public int ProdutoId { get; set; }
    public ProdutoModel? Produto { get; set; }

    public decimal Quantidade { get; set; }
    public decimal Valor { get; set; }
}

