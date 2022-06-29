using AutoMapper;
using MediatR;
using SistemaLocacao.API.ViewModels;
using SistemaLocacao.Core.Notifications;
using SistemaLocacao.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Services
{
    public class FilmeService : BaseService, IFilmeService
    {
        private readonly IMapper _mapper;
        private readonly IFilmeQuerie _filmeQuerie;


        public FilmeService(IMapper mapper,
                              INotificationHandler<DomainNotification> notifications,
                               IFilmeQuerie filmeQuerie)
            : base(notifications)
        {
            _mapper = mapper;
            _filmeQuerie = filmeQuerie;
        }

        public async Task<IEnumerable<FilmeViewModel>> ListarFilmes()
        {
            var filmes = await _filmeQuerie.ListarTodosFilmes();

            return _mapper.Map<IEnumerable<FilmeViewModel>>(filmes);
        }
    }
}
