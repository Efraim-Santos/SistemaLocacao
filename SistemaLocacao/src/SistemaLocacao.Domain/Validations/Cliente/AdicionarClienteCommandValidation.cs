using FluentValidation;
using SistemaLocacao.Domain.Command.Cliente;

namespace SistemaLocacao.Domain.Validations.Cliente
{
    internal class AdicionarClienteCommandValidation : AbstractValidator<AdicionarClienteCommand>
    {
        public AdicionarClienteCommandValidation()
        {
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
