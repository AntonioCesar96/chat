using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Dtos;
using Chat.Domain.Contatos.Interfaces;
using Chat.Infra.Util.AutoMapper;
using System.Threading.Tasks;

namespace Chat.Application.Contatos
{
    public class AutenticacaoContatoApplication : IAutenticacaoContatoApplication
    {
        private readonly IDomainNotificationHandlerAsync<DomainNotification> _notificacaoDeDominio;
        private readonly IAutenticacaoContato _autenticacaoContato;

        public AutenticacaoContatoApplication(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IAutenticacaoContato autenticacaoContato)
        {
            _autenticacaoContato = autenticacaoContato;
            _notificacaoDeDominio = notificacaoDeDominio;
        }

        public async Task<ContatoDto> Autenticar(string email, string senha)
        {
            var contato = await _autenticacaoContato.Autenticar(email, senha);
            return contato.MapTo<ContatoDto>();
        }
    }
}
