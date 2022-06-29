using MediatR;
using SistemaLocacao.Core.Notifications;
using SistemaLocacao.Domain.Command.Locacao;
using SistemaLocacao.Domain.Data;
using SistemaLocacao.Domain.Entity;
using SistemaLocacao.Domain.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaLocacao.Domain.CommandHandlers.Locacao
{
    public class AdicionarLocacaoCommandHandler : DomainNotificationHandler, IRequestHandler<AdicionarLocacaoCommand, LocacaoEntity>
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly ILocacaoQuerie _locacaoQuerie;
        private readonly IClienteQuerie _clienteQuerie;
        private readonly IFilmeRepository _filmeRepository;

        public AdicionarLocacaoCommandHandler(IMediator mediator,
                                              ILocacaoRepository locacaoRepository,
                                              IClienteQuerie clienteQuerie,
                                              IFilmeRepository filmeRepository,
                                              ILocacaoQuerie locacaoQuerie)
            : base(mediator)
        {
            _locacaoRepository = locacaoRepository;
            _clienteQuerie = clienteQuerie;
            _filmeRepository = filmeRepository;
            _locacaoQuerie = locacaoQuerie;
        }

        public async Task<LocacaoEntity> Handle(AdicionarLocacaoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, validation: request.ValidationResult, cancellationToken);
                return null;
            }

            try
            {
                var locacao = await _locacaoQuerie.BuscarLocacaoPorFilme(request.IdFilme);

                if (locacao != null)
                {
                    _ = NotifyBusinesErrorsAsync(request.GetType().Name, "Esse filme já está alugado", cancellationToken);
                    return null;
                }

                var cliente = await _clienteQuerie.BuscarClienteId(request.IdCliente);

                if (cliente == null)
                {
                    _ = NotifyBusinesErrorsAsync(request.GetType().Name, "Não foi possível localizar nenhum cliente com esse id.", cancellationToken);
                    return null;
                }

                var filme = await _filmeRepository.ObterPorId(request.IdFilme);

                if (filme == null)
                {
                    _ = NotifyBusinesErrorsAsync(request.GetType().Name, "Não foi possível localizar nenhum filme com esse id.", cancellationToken);
                    return null;
                }

                var novaLocacao = new LocacaoEntity(cliente.Id, filme.Id, request.DataDevolucao);

                await _locacaoRepository.Adicionar(novaLocacao);

                return await _locacaoRepository.UnitOfWork.Commit() ? novaLocacao : null;
            }
            catch (Exception ex)
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, ex.Message, cancellationToken);
                return null;
            }
        }
    }
}
