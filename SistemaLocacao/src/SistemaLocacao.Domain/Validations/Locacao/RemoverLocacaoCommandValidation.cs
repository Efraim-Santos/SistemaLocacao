using FluentValidation;
using SistemaLocacao.Domain.Command.Locacao;
using System;

namespace SistemaLocacao.Domain.Validations.Locacao
{
    internal class RemoverLocacaoCommandValidation : AbstractValidator<RemoverLocacaoCommand>
    {
        public RemoverLocacaoCommandValidation()
        {
            RuleFor(l => l.IdLocacao)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
