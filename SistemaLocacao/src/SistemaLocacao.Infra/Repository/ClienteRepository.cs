using Microsoft.EntityFrameworkCore;
using SistemaLocacao.Core.Infra;
using SistemaLocacao.Domain.Data;
using SistemaLocacao.Domain.Entity;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaLocacao.Infra.Repository
{
    public class ClienteRepository : Repository<ClienteEntity>, IClienteRepository
    {
        public ClienteRepository(SistemaLocacaoContext context) : base(context)
        {}

        public async Task<ClienteEntity> BuscarClientePorFiltro(Expression<Func<ClienteEntity, bool>> filtro)
        {
            return await dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(filtro);
        }
    }
}
