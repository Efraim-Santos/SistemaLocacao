using SistemaLocacao.Core.Model;
using System;
using System.Collections.Generic;

namespace SistemaLocacao.Domain.Entity
{
    public class ClienteEntity : EntityBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        private ClienteEntity()
        {}

        public ClienteEntity(string nome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        public void AlterarEntidade(string nome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        public IEnumerable<LocacaoEntity> Locacoes { get; set; }
    }
}
