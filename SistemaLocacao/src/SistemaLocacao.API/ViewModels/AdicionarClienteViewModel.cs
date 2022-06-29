using System;

namespace SistemaLocacao.API.ViewModels
{
    public class ClienteRequestViewModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

    }
}
