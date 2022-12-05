namespace BackOffice.WebApi.Contracts;

public class PagamentoRequestModel
{
    public decimal Valor { get; set; }
    public int TipoDePagamento { get; set; }
    public DateTime Vencimento { get; set; }
    public DateTime? Pagamento { get; set; }
    public decimal? ValorPago { get; set; }
}
