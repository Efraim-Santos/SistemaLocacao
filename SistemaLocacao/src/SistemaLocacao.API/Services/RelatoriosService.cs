using AutoMapper;
using MediatR;
using SistemaLocacao.API.ViewModels;
using SistemaLocacao.Core.Notifications;
using SistemaLocacao.Domain.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Services
{
    public class RelatoriosService : BaseService, IRelatoriosService
    {
        private readonly ILocacaoQuerie _locacaoQuerie;
        private readonly IFilmeQuerie _filmeQuerie;
        private readonly IMapper _mapper;


        public RelatoriosService(INotificationHandler<DomainNotification> notifications,
                              ILocacaoQuerie locacaoQuerie,
                              IFilmeQuerie filmeQuerie,
                              IMapper mapper)
            : base(notifications)
        {
            _locacaoQuerie = locacaoQuerie;
            _filmeQuerie = filmeQuerie;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteViewModel>> ClienteEmAtrasoDelolucao()
        {
            var clienteEmAtrasoDelolucao = await _locacaoQuerie.ListarLocacoesDeFilmesEmAtraso();

            return _mapper.Map<IEnumerable<ClienteViewModel>>(clienteEmAtrasoDelolucao.Select(l => l.Cliente));
        }  
        
        public async Task<IEnumerable<FilmeViewModel>> FilmesQueNuncaForamAlugados()
        {
            var filmesQueNuncaForamAlugados = await _filmeQuerie.ListarFilmesNuncaLocados();

            return _mapper.Map<IEnumerable<FilmeViewModel>>(filmesQueNuncaForamAlugados);
        } 
        
        public async Task<IEnumerable<FilmeViewModel>> FilmesMaisAlugadosAno()
        {
            var filmesMaisAlugadosAnoTop5 = await _locacaoQuerie.ListarFilmesMaisLocados();

            return _mapper.Map<IEnumerable<FilmeViewModel>>(filmesMaisAlugadosAnoTop5.Select(l => l.Filme));
        }  
        
        public async Task<IEnumerable<FilmeViewModel>> FilmesMenosAlugadosSemana()
        {
            var filmesMenosAlugadosSemanaTop3 = await _locacaoQuerie.ListarFilmesMenosLocadosSemana();

            return _mapper.Map<IEnumerable<FilmeViewModel>>(filmesMenosAlugadosSemanaTop3.Select(l => l.Filme));
        } 
        
        public async Task<ClienteViewModel> ClienteMaisAlugou()
        {
            var clienteMaisAlugouTop2 = await _locacaoQuerie.ListarClienteQueMaisAlugou();

            return _mapper.Map<ClienteViewModel>(clienteMaisAlugouTop2.Cliente);
        }
    }
}
