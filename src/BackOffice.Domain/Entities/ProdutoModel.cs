using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Domain.Entities;

public class ProdutoModel : BaseModel
{
    public string Descricao { get; set; }

    public decimal Valor { get; set; }
    
    public ICollection<PedidoItemModel> ItensDePedidos { get; set; }
}
