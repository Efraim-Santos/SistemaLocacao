using System.Collections.Generic;

namespace SistemaLocacao.API.Model
{
    public class ResponseModel<T> where T : class
    {
        public List<string> Messagens { get; set; }
        public T Resultado { get; set; }
    }
}
