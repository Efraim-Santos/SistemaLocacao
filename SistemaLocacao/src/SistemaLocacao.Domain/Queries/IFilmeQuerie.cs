using SistemaLocacao.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.Domain.Queries
{
    public interface IFilmeQuerie
    {
        /// <summary>
        /// Listar filmes nunca locados
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FilmeEntity>> ListarFilmesNuncaLocados();

        /// <summary>
        /// Listar todos os filmes
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FilmeEntity>> ListarTodosFilmes();
    }
}
