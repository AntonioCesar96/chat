using Chat.Domain.Common.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;

namespace Chat.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
        protected readonly IDomainNotificationHandlerAsync<DomainNotification> NotificacaoDeDominio;

        protected BaseController(IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio)
        {
            NotificacaoDeDominio = notificacaoDeDominio;
            // Thread.Sleep(1000);
        }

        protected bool OperacaoValida() => !NotificacaoDeDominio.HasNotifications();

        protected ActionResult ResponderErros()
        {
            return Ok(new { Erros = NotificacaoDeDominio.GetNotifications().Select(n => n.Value) });
        }
    }
}
