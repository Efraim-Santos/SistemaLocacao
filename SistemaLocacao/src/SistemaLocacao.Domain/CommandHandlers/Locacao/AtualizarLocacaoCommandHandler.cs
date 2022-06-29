using MediatR;
using SistemaLocacao.Core.Notifications;
using SistemaLocacao.Domain.Command.Locacao;
using SistemaLocacao.Domain.Data;
using SistemaLocacao.Domain.Entity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaLocacao.Domain.CommandHandlers.Locacao
{
    public class AtualizarLocacaoCommandHandler : DomainNotificationHandler, IRequestHandler<AtualizarLocacaoCommand, LocacaoEntity>
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IFilmeRepository _filmeRepository;

        public AtualizarLocacaoCommandHandler(IMediator mediator,
                                              ILocacaoRepository locacaoRepository,
                                              IFilmeRepository filmeRepository)
            : base(mediator)
        {
            _locacaoRepository = locacaoRepository;
            _filmeRepository = filmeRepository;
        }

        public async Task<LocacaoEntity> Handle(AtualizarLocacaoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, validation: request.ValidationResult, cancellationToken);
                return null;
            }

            try
            {
                var locacao = await _locacaoRepository.ObterPorId(request.IdLocacao);

                if (locacao == null)
                {
                    _ = NotifyBusinesErrorsAsync(request.GetType().Name, "Não foi possível encontrar a locação com esse id.", cancellationToken);
                    return null;
                }

                var filme = await _filmeRepository.ObterPorId(request.IdFilme);

                if (filme == null)
                {
                    _ = NotifyBusinesErrorsAsync(request.GetType().Name, "Não foi possível localizar nenhum filme com esse id.", cancellationToken);
                    return null;
                }

                locacao.AlterarEntidade(request.IdFilme, request.DataDevolucao);

                _locacaoRepository.Atualizar(locacao);

                return await _locacaoRepository.UnitOfWork.Commit() ? locacao : null;
            }
            catch (Exception ex)
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, ex.Message, cancellationToken);
                return null;
            }
        }
    }
}
