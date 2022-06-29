using AutoMapper;
using SistemaLocacao.API.ViewModels;
using SistemaLocacao.Domain.Entity;

namespace SistemaLocacao.API.Mapping
{
    public class LocacaoViewModelToLocacaoCommandEntity : Profile
    {
        public LocacaoViewModelToLocacaoCommandEntity()
        {
            CreateMap<LocacaoEntity, LocacaoViewModel>();
        }
    }
}
