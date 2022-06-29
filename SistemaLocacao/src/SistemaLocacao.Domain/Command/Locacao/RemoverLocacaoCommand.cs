using SistemaLocacao.Core.Command;
using SistemaLocacao.Domain.Validations.Locacao;

namespace SistemaLocacao.Domain.Command.Locacao
{
    public class RemoverLocacaoCommand : Command<bool>
    {
        public int IdLocacao { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new RemoverLocacaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
