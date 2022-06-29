using AutoMapper;
using MediatR;
using SistemaLocacao.API.Model;
using SistemaLocacao.API.ViewModels;
using SistemaLocacao.Core.Notifications;
using SistemaLocacao.Domain.Command.Cliente;
using SistemaLocacao.Domain.Entity;
using SistemaLocacao.Domain.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IClienteQuerie _clienteQuerie;


        public ClienteService(IMapper mapper,
                              IMediator mediator,
                              INotificationHandler<DomainNotification> notifications,
                              IClienteQuerie clienteQuerie)
            : base(notifications)
        {
            _mapper = mapper;
            _mediator = mediator;
            _clienteQuerie = clienteQuerie;
        }
        public async Task<ResponseModel<ClienteViewModel>> Adicionar(ClienteRequestViewModel cliente)
        {
            var clienteCommand = _mapper.Map<AdicionarClienteCommand>(cliente);

            var result = await _mediator.Send<ClienteEntity>(clienteCommand, default);

            return new ResponseModel<ClienteViewModel>
            {
                Resultado = _mapper.Map<ClienteViewModel>(result),
                Messagens =  ObterMensagens().ToList()
            };
        }

        public async Task<ResponseModel<ClienteViewModel>> Atualizar(int id, ClienteRequestViewModel cliente)
        {
            var clienteCommand = _mapper.Map<AtualizarClienteCommand>(cliente);

            clienteCommand.IdCliente = id;

            var result = await _mediator.Send<ClienteEntity>(clienteCommand, default);

            return new ResponseModel<ClienteViewModel>
            {
                Resultado = _mapper.Map<ClienteViewModel>(result),
                Messagens = ObterMensagens().ToList()
            };
        }

        public async Task<bool> RemoverCliente(int id)
        {
            var clienteCommand = new RemoverClienteCommand { IdCliente = id};

            return await _mediator.Send<bool>(clienteCommand, default);
        }

        public async Task<ClienteViewModel> BuscarClienteId(int id)
        {
            var cliente = await _clienteQuerie.BuscarClienteId(id);

            return _mapper.Map<ClienteViewModel>(cliente);
        }

        public async Task<ClienteViewModel> BuscarRegistroCliente(string nome, string cpf)
        {
            var cliente = await _clienteQuerie.BuscarClienteNomeCpf(nome, cpf);

            return _mapper.Map<ClienteViewModel>(cliente);
        }

        public async Task<IEnumerable<ClienteViewModel>> ListarClientes()
        {
            var clientes = await _clienteQuerie.ObterTodosClientes();

            return _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
        }
    }
}
