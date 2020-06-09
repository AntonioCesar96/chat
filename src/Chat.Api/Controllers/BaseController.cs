using Chat.Domain.Common.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        }

        protected bool OperacaoValida() => !NotificacaoDeDominio.HasNotifications();

        protected BadRequestObjectResult BadRequestResponse()
        {
            return BadRequest(NotificacaoDeDominio.GetNotifications().Select(n => n.Value));
        }
    }
}
