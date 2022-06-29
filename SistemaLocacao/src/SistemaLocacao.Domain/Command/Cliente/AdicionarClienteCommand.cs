using SistemaLocacao.Core.Command;
using SistemaLocacao.Domain.Entity;
using SistemaLocacao.Domain.Validations.Cliente;
using System;

namespace SistemaLocacao.Domain.Command.Cliente
{
    public class AdicionarClienteCommand : Command<ClienteEntity>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AdicionarClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}