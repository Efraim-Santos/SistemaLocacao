using AutoMapper;
using SistemaLocacao.API.ViewModels;
using SistemaLocacao.Domain.Entity;

namespace SistemaLocacao.API.Mapping
{
    public class FilmeViewModelToFilmeEntityCommand : Profile
    {
        public FilmeViewModelToFilmeEntityCommand()
        {
            CreateMap<FilmeEntity, FilmeViewModel>();
        }
    }
}
