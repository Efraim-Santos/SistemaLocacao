using MediatR;
using SistemaLocacao.Core.Notifications;
using SistemaLocacao.Domain.Command.Cliente;
using SistemaLocacao.Domain.Data;
using SistemaLocacao.Domain.Entity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaLocacao.Domain.CommandHandlers.Cliente
{
    public class AdicionarClienteCommandHandler : DomainNotificationHandler, IRequestHandler<AdicionarClienteCommand, ClienteEntity>
    {
        private readonly IClienteRepository _clienteRepository;

        public AdicionarClienteCommandHandler(IMediator mediator,
                                              IClienteRepository clienteRepository)
            : base(mediator)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteEntity> Handle(AdicionarClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, validation: request.ValidationResult, cancellationToken);
                return null;
            }

            try
            {
                var novoCliente = new ClienteEntity(request.Nome, request.Cpf, request.DataNascimento);

                await _clienteRepository.Adicionar(novoCliente);

                return await _clienteRepository.UnitOfWork.Commit() ? novoCliente : null;
            }
            catch (Exception ex)
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, ex.Message, cancellationToken);
                return null;
            }
        }
    }
}
