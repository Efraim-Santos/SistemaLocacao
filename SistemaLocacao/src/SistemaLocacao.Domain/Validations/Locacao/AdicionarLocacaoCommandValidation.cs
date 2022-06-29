using FluentValidation;
using SistemaLocacao.Domain.Command.Locacao;
using System;

namespace SistemaLocacao.Domain.Validations.Locacao
{
    internal class AdicionarLocacaoCommandValidation : AbstractValidator<AdicionarLocacaoCommand>
    {
        public AdicionarLocacaoCommandValidation()
        {
            RuleFor(l => l.IdCliente)
                .NotNull()
                .GreaterThan(0);

            RuleFor(l => l.IdFilme)
               .NotNull()
               .GreaterThan(0);

            RuleFor(l => l.DataDevolucao)
               .NotNull()
               .Must(data => data > DateTime.MinValue);
        }
    }
}
