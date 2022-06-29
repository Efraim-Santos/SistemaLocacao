using SistemaLocacao.Domain.Data;
using SistemaLocacao.Domain.Entity;
using SistemaLocacao.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.Infra.Queries
{
    public class FilmeQuerie : IFilmeQuerie
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeQuerie(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<IEnumerable<FilmeEntity>> ListarFilmesNuncaLocados()
            => await _filmeRepository.BuscarFilmesNuncaLocados();

        public async Task<IEnumerable<FilmeEntity>> ListarTodosFilmes()
               => await _filmeRepository.ObterTodos();
    }
}
