using FluentValidation;
using SistemaLocacao.Domain.Command.Locacao;
using System;

namespace SistemaLocacao.Domain.Validations.Locacao
{
    internal class AtualizarLocacaoCommandValidation : AbstractValidator<AtualizarLocacaoCommand>
    {
        public AtualizarLocacaoCommandValidation()
        {
            RuleFor(l => l.IdLocacao)
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
