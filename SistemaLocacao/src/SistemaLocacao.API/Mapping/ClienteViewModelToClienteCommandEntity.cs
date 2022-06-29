using AutoMapper;
using SistemaLocacao.API.ViewModels;
using SistemaLocacao.Domain.Command.Cliente;
using SistemaLocacao.Domain.Entity;

namespace SistemaLocacao.API.Mapping
{
    public class ClienteViewModelToClienteCommandEntity : Profile
    {
        public ClienteViewModelToClienteCommandEntity()
        {
            CreateMap<ClienteViewModel, AdicionarClienteCommand>();

            CreateMap<ClienteRequestViewModel, AdicionarClienteCommand>();

            CreateMap<ClienteViewModel, AtualizarClienteCommand>();

            CreateMap<ClienteRequestViewModel, AtualizarClienteCommand>();

            CreateMap<ClienteEntity, ClienteViewModel>();
        }
    }
}
