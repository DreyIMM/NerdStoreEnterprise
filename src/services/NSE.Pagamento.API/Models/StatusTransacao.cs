namespace NSE.Pagamento.API.Models
{
    public enum StatusTransacao
    {
        Autorizado = 1,
        Pago,
        Negado,
        Estornado,
        Cancelado
    }

    public enum TipoPagamento
    {
        CartaoCredito = 1,
        Boleto
    }

}
