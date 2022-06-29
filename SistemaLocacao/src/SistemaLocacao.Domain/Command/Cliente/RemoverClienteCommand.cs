using SistemaLocacao.Core.Command;
using SistemaLocacao.Domain.Validations.Cliente;

namespace SistemaLocacao.Domain.Command.Cliente
{
    public class RemoverClienteCommand : Command<bool>
    {
        public int IdCliente { get; set; }
        public override bool IsValid()
        {
            ValidationResult = new RemoverClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
