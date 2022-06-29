using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaLocacao.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private readonly List<DomainNotification> _notificacoes;
        private readonly IMediator _mediator;

        public DomainNotificationHandler(IMediator mediator)
        {
            _notificacoes = new List<DomainNotification>();
            _mediator = mediator;
        }

        public Task Handle(DomainNotification notificacao, CancellationToken cancellationToken)
        {
            _notificacoes.Add(notificacao);

            return Task.CompletedTask;
        }

        public async Task NotifyBusinesErrorsAsync(string command, string messagem, CancellationToken cancellationToken = default)
            => await _mediator.Publish(new DomainNotification(command, messagem), cancellationToken);

        public async Task NotifyBusinesErrorsAsync(string command, ValidationResult validation, CancellationToken cancellationToken = default)
        {
            foreach (var erro in validation.Errors)
                await _mediator.Publish(new DomainNotification(command, erro.ErrorMessage), cancellationToken);
        }

        public virtual List<DomainNotification> ObterNotificacoes()
        {
            return _notificacoes;
        }
    }
}
