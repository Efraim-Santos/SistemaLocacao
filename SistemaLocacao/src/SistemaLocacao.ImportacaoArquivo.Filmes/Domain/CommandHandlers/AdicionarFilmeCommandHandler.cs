using MediatR;
using SistemaLocacao.Core.Notifications;
using SistemaLocacao.Domain.Data;
using SistemaLocacao.Domain.Entity;
using SistemaLocacao.ImportacaoArquivo.Filmes.Domain.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaLocacao.ImportacaoArquivo.Filmes.Domain.CommandHandlers
{
    public class AdicionarFilmeCommandHandler : DomainNotificationHandler, IRequestHandler<AdicionarFilmeCommand, bool>
    {
        private readonly IFilmeRepository _filmeRepository;
        public AdicionarFilmeCommandHandler(IMediator mediator,
                                            IFilmeRepository filmeRepository) 
            : base(mediator)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<bool> Handle(AdicionarFilmeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, validation: request.ValidationResult, cancellationToken);
                return false;
            }

            try
            {
                var novoFilme = new FilmeEntity(request.Titulo, request.ClassificaoIndicativa, request.Lancamento);

                await _filmeRepository.Adicionar(novoFilme);

                return await _filmeRepository.UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, ex.Message, cancellationToken);
                return false;
            }
        }
    }
}
