namespace BackOffice.Domain.Entities;

public enum PedidoStatusEnum
{
    Criado = 0,
    AguardaPagamento = 1,
    Pago = 2,
    AguardaRetirada = 3,
    EmTransito = 4,
    Entregue = 5,
    Devolvido = 6,
    Cancelado = 7,
    Finalizado = 8
}
