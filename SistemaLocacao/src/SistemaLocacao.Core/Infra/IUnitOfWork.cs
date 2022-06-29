using System.Threading.Tasks;

namespace SistemaLocacao.Core.Infra
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
