using FluentValidation;
using SistemaLocacao.ImportacaoArquivo.Filmes.Domain.Commands;

namespace SistemaLocacao.ImportacaoArquivo.Filmes.Domain.Validations
{
    internal class AdicionarFilmeCommandValidation : AbstractValidator<AdicionarFilmeCommand>
    {
        public AdicionarFilmeCommandValidation()
        {
            RuleFor(f => f.Titulo)
                .NotEmpty();

            RuleFor(f => f.ClassificaoIndicativa)
                .NotNull()
                .GreaterThan(0);

            RuleFor(f => f.Lancamento)
                .NotNull()
                .Must(l => l != 0 || l != 1)
                .WithMessage("O valor do lançamento só pode ser 0 ou 1");
        }
    }
}
