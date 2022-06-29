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
    public class AtualizarClienteCommandHandler : DomainNotificationHandler, IRequestHandler<AtualizarClienteCommand, ClienteEntity>
    {
        private readonly IClienteRepository _clienteRepository;

        public AtualizarClienteCommandHandler(IMediator mediator,
                                              IClienteRepository clienteRepository)
            : base(mediator)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteEntity> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, validation: request.ValidationResult, cancellationToken);
                return null;
            }

            try
            {
                var cliente = await _clienteRepository.ObterPorId(request.IdCliente);

                if(cliente == null)
                {
                    _ = NotifyBusinesErrorsAsync(request.GetType().Name, "Não foi possível localizar nenhum cliente com esse id.", cancellationToken);
                    return null;
                }

                cliente.AlterarEntidade(request.Nome, request.Cpf, request.DataNascimento);

                _clienteRepository.Atualizar(cliente);

                return await _clienteRepository.UnitOfWork.Commit() ? cliente : null;
            }
            catch (Exception ex)
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, ex.Message, cancellationToken);
                return null;
            }
        }
    }
}
