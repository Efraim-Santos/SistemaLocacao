using SistemaLocacao.Core.Command;
using SistemaLocacao.Domain.Entity;
using SistemaLocacao.Domain.Validations.Locacao;
using System;

namespace SistemaLocacao.Domain.Command.Locacao
{
    public class AtualizarLocacaoCommand : Command<LocacaoEntity>
    {
        public int IdLocacao { get; set; }
        public int IdFilme { get; set; }
        public DateTime DataDevolucao { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarLocacaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
