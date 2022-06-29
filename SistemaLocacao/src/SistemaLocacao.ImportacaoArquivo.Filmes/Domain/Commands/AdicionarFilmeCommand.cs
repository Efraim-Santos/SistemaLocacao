using SistemaLocacao.Core.Command;
using SistemaLocacao.ImportacaoArquivo.Filmes.Domain.Validations;
using System;

namespace SistemaLocacao.ImportacaoArquivo.Filmes.Domain.Commands
{
    public class AdicionarFilmeCommand : Command<bool>
    {
        public string Titulo { get; set; }
        public int ClassificaoIndicativa { get; set; }
        public Byte Lancamento { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AdicionarFilmeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
