using FluentValidation;
using SistemaLocacao.Domain.Command.Cliente;

namespace SistemaLocacao.Domain.Validations.Cliente
{
    internal class AtualizarClienteCommandValidation : AbstractValidator<AtualizarClienteCommand>
    {
        public AtualizarClienteCommandValidation()
        {
            RuleFor(c => c.IdCliente)
                .NotNull()
                .GreaterThan(0);

            RuleFor(c => c.Nome)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(c => c.Cpf)
                .NotEmpty()
                .MaximumLength(11);

            RuleFor(c => c.DataNascimento)
             .Must(data => data > System.DateTime.MinValue);
        }
    }
}
