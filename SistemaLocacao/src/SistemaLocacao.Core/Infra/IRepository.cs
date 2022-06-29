using SistemaLocacao.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.Core.Infra
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IUnitOfWork UnitOfWork { get; }

        Task Adicionar(TEntity entidade);
        void Atualizar(TEntity departamento);
        void Dispose();
        Task<TEntity> ObterPorId(int id);
        Task<List<TEntity>> ObterTodos();
        void Remover(TEntity departamento);
    }
}
