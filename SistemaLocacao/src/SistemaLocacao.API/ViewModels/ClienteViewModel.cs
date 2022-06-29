using System;

namespace SistemaLocacao.API.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public static implicit operator ClienteViewModel(FilmeViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
