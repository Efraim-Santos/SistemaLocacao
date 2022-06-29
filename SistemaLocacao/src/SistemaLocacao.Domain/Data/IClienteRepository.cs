using SistemaLocacao.Core.Infra;
using SistemaLocacao.Domain.Entity;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaLocacao.Domain.Data
{
    public interface IClienteRepository : IRepository<ClienteEntity>
    {

        Task<ClienteEntity> BuscarClientePorFiltro(Expression<Func<ClienteEntity, bool>> filtro);
    }
}
