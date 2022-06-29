using MediatR;
using SistemaLocacao.Core.Notifications;
using SistemaLocacao.Domain.Command.Locacao;
using SistemaLocacao.Domain.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaLocacao.Domain.CommandHandlers.Locacao
{
    public class RemoverLocacaoCommandHandler : DomainNotificationHandler, IRequestHandler<RemoverLocacaoCommand, bool>
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public RemoverLocacaoCommandHandler(IMediator mediator,
                                            ILocacaoRepository locacaoRepository)
            : base(mediator)
        {
            _locacaoRepository = locacaoRepository;
        }

        public async Task<bool> Handle(RemoverLocacaoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, validation: request.ValidationResult, cancellationToken);
                return false;
            }

            try
            {
                var locacao = await _locacaoRepository.ObterPorId(request.IdLocacao);

                if (locacao == null)
                {
                    _ = NotifyBusinesErrorsAsync(request.GetType().Name, "Não foi possível localizar nenhuma locação com esse id.", cancellationToken);
                    return false;
                }

                _locacaoRepository.Remover(locacao);

                return await _locacaoRepository.UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, ex.Message, cancellationToken);
                return false;
            }
        }
    }
}
