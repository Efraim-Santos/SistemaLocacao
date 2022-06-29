using MediatR;
using SistemaLocacao.API.Model;
using SistemaLocacao.API.ViewModels;
using SistemaLocacao.Core.Notifications;
using SistemaLocacao.ImportacaoArquivo.Filmes.Domain.Commands;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Services
{
    public class ImportacoesArquivoService : BaseService, IImportacoesArquivoService
    {
        private readonly IMediator _mediator;

        public ImportacoesArquivoService(IMediator mediator,
                                         INotificationHandler<DomainNotification> notifications)
            :base(notifications)
        {
            _mediator = mediator;
        }

        public async Task<ResponseModel<ImportacaoViewModel>> ImportarFilmes(ImportacaoViewModel importacaoViewModel)
        {
            var importacaoCommand = new ImportarFilmesCommand
            {
                ArquivoBase64 = Encoding.UTF8.GetString(importacaoViewModel.ArquivoAnexoBytes)
            };

            await _mediator.Send<bool>(importacaoCommand, default);

            return new ResponseModel<ImportacaoViewModel>
            {
                Resultado = new ImportacaoViewModel(),
                Messagens = ObterMensagens().ToList()
            };
        }
    }
}
