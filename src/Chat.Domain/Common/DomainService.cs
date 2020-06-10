using Chat.Domain.Common.Notifications;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Chat.Domain.Common
{
    public abstract class DomainService
    {
        public readonly IDomainNotificationHandlerAsync<DomainNotification> _notificacaoDeDominio;

        protected DomainService(IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio)
        {
            _notificacaoDeDominio = notificacaoDeDominio;
        }

        public async Task NotificarValidacoesDeDominio(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
                await _notificacaoDeDominio.HandleAsync(
                    new DomainNotification(TipoDeNotificacao.ErroDeDominio.ToString(), erro.ErrorMessage));
        }

        public async Task QuandoNuloNotificarSobreDominio(object dominio, string nomeDoDominio, string msg)
        {
            if (dominio == null)
                await _notificacaoDeDominio.HandleAsync(
                    new DomainNotification(TipoDeNotificacao.ErroDeServico.ToString(),
                    string.Format(msg, nomeDoDominio)));
        }

        public async Task NotificarErroDeServico(string msg)
        {
            await _notificacaoDeDominio.HandleAsync(
                new DomainNotification(TipoDeNotificacao.ErroDeServico.ToString(), msg));
        }

        public async Task NotificarErroDeDominio(string msg)
        {
            await _notificacaoDeDominio.HandleAsync(
                new DomainNotification(TipoDeNotificacao.ErroDeDominio.ToString(), msg));
        }
    }
}
