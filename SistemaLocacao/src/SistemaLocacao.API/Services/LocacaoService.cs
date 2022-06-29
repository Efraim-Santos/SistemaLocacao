using AutoMapper;
using MediatR;
using SistemaLocacao.API.Model;
using SistemaLocacao.API.ViewModels;
using SistemaLocacao.Core.Notifications;
using SistemaLocacao.Domain.Command.Locacao;
using SistemaLocacao.Domain.Entity;
using SistemaLocacao.Domain.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Services
{
    public class LocacaoService : BaseService, ILocacaoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILocacaoQuerie _locacaoQuerie;


        public LocacaoService(IMapper mapper,
                              IMediator mediator,
                              INotificationHandler<DomainNotification> notifications,
                              ILocacaoQuerie locacaoQuerie)
            : base(notifications)
        {
            _mapper = mapper;
            _mediator = mediator;
            _locacaoQuerie = locacaoQuerie;
        }
        public async Task<ResponseModel<LocacaoViewModel>> Adicionar(int idCliente, int idFilme, DevolverLocacaoViewModel locacao)
        {
            var locacaoCommand = new AdicionarLocacaoCommand
            {
                IdCliente = idCliente,
                IdFilme = idFilme,
                DataDevolucao = locacao.DataDevolucao
            };

            var result = await _mediator.Send<LocacaoEntity>(locacaoCommand, default);

            return new ResponseModel<LocacaoViewModel>
            {
                Resultado = _mapper.Map<LocacaoViewModel>(result),
                Messagens = ObterMensagens().ToList()
            };
        }

        public async Task<ResponseModel<LocacaoViewModel>> Atualizar(int id, int idFilme, DevolverLocacaoViewModel locacao)
        {
            var locacaoCommand = new AtualizarLocacaoCommand
            {
                IdLocacao = id,
                IdFilme = idFilme,
                DataDevolucao = locacao.DataDevolucao
            };

            var result = await _mediator.Send<LocacaoEntity>(locacaoCommand, default);

            return new ResponseModel<LocacaoViewModel>
            {
                Resultado = _mapper.Map<LocacaoViewModel>(result),
                Messagens = ObterMensagens().ToList()
            };
        }

        public async Task<bool> RemoverLocacao(int id)
        {
            var locacaoCommand = new RemoverLocacaoCommand { IdLocacao = id };

            return await _mediator.Send<bool>(locacaoCommand, default);
        }

        public async Task<LocacaoViewModel> BuscarLocacaoId(int id)
        {
            var locacao = await _locacaoQuerie.BuscarLocacaoId(id);

            return _mapper.Map<LocacaoViewModel>(locacao);
        }


        public async Task<IEnumerable<LocacaoViewModel>> ListarLocacaos()
        {
            var locacaos = await _locacaoQuerie.ObterTodasLocacoes();

            return _mapper.Map<IEnumerable<LocacaoViewModel>>(locacaos);
        }
    }
}
