using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using SistemaLocacao.Core.Notifications;
using SistemaLocacao.ImportacaoArquivo.Filmes.Domain.Commands;
using SistemaLocacao.ImportacaoArquivo.Filmes.Domain.Dto;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaLocacao.ImportacaoArquivo.Filmes.Domain.CommandHandlers
{
    public class ImportarFilmesCommandHandler : DomainNotificationHandler, IRequestHandler<ImportarFilmesCommand, bool>
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Configuração para leitura do arquivo
        /// </summary>
        private static CsvConfiguration CONFIG = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            Delimiter = ";",
            MissingFieldFound = null
        };

        public ImportarFilmesCommandHandler(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> Handle(ImportarFilmesCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, validation: request.ValidationResult, cancellationToken);
                return false;
            }

            try
            {
                using var sr = new StringReader(request.ArquivoBase64);
                using var csv = new CsvReader(sr, CONFIG);
                
                var linhasFilmes = csv.GetRecords<FilmesDto>().ToList();

                linhasFilmes.RemoveAt(0);

                foreach (var filme in linhasFilmes)
                {
                    var filmeCommand = new AdicionarFilmeCommand
                    {
                        Titulo = filme.Titulo,
                        ClassificaoIndicativa = int.Parse(filme.ClassificaoIndicativa),
                        Lancamento = byte.Parse(filme.Lancamento)
                    };

                    var eSucesso = await _mediator.Send<bool>(filmeCommand, default);

                    if (!eSucesso)
                    {
                        _ = NotifyBusinesErrorsAsync(request.GetType().Name, "Algo de errado nos dados do arquivo", cancellationToken);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                _ = NotifyBusinesErrorsAsync(request.GetType().Name, ex.Message, cancellationToken);
                return false;
            }
        }
    }
}