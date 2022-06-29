using MediatR;
using SistemaLocacao.Core.Notifications;
using SistemaLocacao.Domain.Command.Cliente;
using SistemaLocacao.Domain.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaLocacao.Domain.CommandHandlers.Cliente
{
    public class RemoverClienteCommandHandler : DomainNotificationHandler, IRequestHandler<RemoverClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;

        public RemoverClienteCommandHandler(IMediator mediator,
                                            IClienteRepository clienteRepository)
            : base(mediator)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Handle(RemoverClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, validation: request.ValidationResult, cancellationToken);
                return false;
            }

            try
            {
                var cliente = await _clienteRepository.ObterPorId(request.IdCliente);

                if (cliente == null)
                {
                    _ = NotifyBusinesErrorsAsync(request.GetType().Name, "Não foi possível localizar nenhum cliente com esse id.", cancellationToken);
                    return false;
                }

                _clienteRepository.Remover(cliente);

                return await _clienteRepository.UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, ex.Message, cancellationToken);
                return false;
            }
        }
    }
}
