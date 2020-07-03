using AutoMapper;
using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Dtos;
using Chat.Domain.Contatos.Interfaces;
using System.Threading.Tasks;

namespace Chat.Application.Contatos
{
    public class AutenticacaoContatoApplication : IAutenticacaoContatoApplication
    {
        private readonly IDomainNotificationHandlerAsync<DomainNotification> _notificacaoDeDominio;
        private readonly IAutenticacaoContato _autenticacaoContato;
        private readonly IMapper _mapper;

        public AutenticacaoContatoApplication(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IAutenticacaoContato autenticacaoContato,
            IMapper mapper)
        {
            _autenticacaoContato = autenticacaoContato;
            _notificacaoDeDominio = notificacaoDeDominio;
            _mapper = mapper;
        }

        public async Task<ContatoDto> Autenticar(string email, string senha)
        {
            var contato = await _autenticacaoContato.Autenticar(email, senha);
            return _mapper.Map<ContatoDto>(contato);
        }
    }
}
