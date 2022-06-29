using MediatR;

namespace SistemaLocacao.Core.Notifications
{
    public class DomainNotification : INotification
    {
        public string Commamd { get; private set; }
        public string Mensagem { get; private set; }

        public DomainNotification(string commamd, string mensagem)
        {
            Commamd = commamd;
            Mensagem = $"Processamento {commamd} - {mensagem}";
        }
    }
}
