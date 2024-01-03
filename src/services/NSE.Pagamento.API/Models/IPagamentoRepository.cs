using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using NSE.Core.Data;

namespace NSE.Pagamento.API.Models
{
    public interface IPagamentoRepository : IRepository<Pagamentos>
    {
        void AdicionarPagamento(Pagamentos pagamento);
        void AdicionarTransacao(Transacao transacao);
        Task<Pagamentos> ObterPagamentoPorPedidoId(Guid pedidoId);
        Task<IEnumerable<Transacao>> ObterTransacaoesPorPedidoId(Guid pedidoId);
    }
}
