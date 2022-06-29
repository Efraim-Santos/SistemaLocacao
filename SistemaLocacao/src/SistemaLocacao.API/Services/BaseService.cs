using MediatR;
using SistemaLocacao.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaLocacao.API.Services
{
    public class BaseService
    {
        private readonly DomainNotificationHandler _notifications;

        public BaseService(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public IEnumerable<string> ObterMensagens()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Mensagem);
        }
    }
}
