using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Domain.Entities;

public class ClienteModel : BaseModel
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Celular { get; set; }

    public ICollection<PedidoModel>? Pedidos { get; set; }
}
