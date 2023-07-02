using NSE.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Models
{
    public interface IClienteRepository : IRepository<ClienteEntity>
    {
        void Adicionar(ClienteEntity cliente);
        Task<IEnumerable<ClienteEntity>> ObterTodos();
        Task<ClienteEntity> ObterPorCpf(string cpf);
    }
}
