using FluentValidation;
using SistemaLocacao.Domain.Command.Cliente;

namespace SistemaLocacao.Domain.Validations.Cliente
{
    internal class RemoverClienteCommandValidation : AbstractValidator<RemoverClienteCommand>
    {
        public RemoverClienteCommandValidation()
        {
            RuleFor(c => c.IdCliente)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
