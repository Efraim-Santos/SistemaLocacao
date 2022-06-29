using SistemaLocacao.Core.Command;
using SistemaLocacao.ImportacaoArquivo.Filmes.Domain.Validations;

namespace SistemaLocacao.ImportacaoArquivo.Filmes.Domain.Commands
{
    public class ImportarFilmesCommand : Command<bool>
    {
        public string ArquivoBase64 { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ImportarFilmeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
