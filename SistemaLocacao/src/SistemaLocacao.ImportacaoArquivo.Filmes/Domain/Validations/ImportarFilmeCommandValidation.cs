using FluentValidation;
using SistemaLocacao.ImportacaoArquivo.Filmes.Domain.Commands;

namespace SistemaLocacao.ImportacaoArquivo.Filmes.Domain.Validations
{
    internal class ImportarFilmeCommandValidation : AbstractValidator<ImportarFilmesCommand>
    {
        public ImportarFilmeCommandValidation()
        {
            RuleFor(i => i.ArquivoBase64)
                .NotEmpty();
        }
    }
}
