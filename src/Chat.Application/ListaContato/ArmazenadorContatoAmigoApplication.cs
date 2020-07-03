using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chat.Application.ListaContato.Interfaces;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Dtos;
using Chat.Domain.ListaContatos.Dtos;
using Chat.Domain.ListaContatos.Interfaces;

namespace Chat.Application.ListaContato
{
    public class ArmazenadorContatoAmigoApplication : IArmazenadorContatoAmigoApplication
    {
        private readonly IDomainNotificationHandlerAsync<DomainNotification> _notificacaoDeDominio;
        private readonly IArmazenadorContatoAmigo _armazenadorContatoAmigo;
        private readonly IMapper _mapper;

        public ArmazenadorContatoAmigoApplication(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IArmazenadorContatoAmigo armazenadorContatoAmigo,
            IMapper mapper)
        {
            _notificacaoDeDominio = notificacaoDeDominio;
            _armazenadorContatoAmigo = armazenadorContatoAmigo;
            _mapper = mapper;
        }

        public async Task<object> Salvar(ContatoAmigoCriacaoDto dto)
        {
            var listaContato = await _armazenadorContatoAmigo.Salvar(dto);

            if (_notificacaoDeDominio.HasNotifications())
                return new { Erros = _notificacaoDeDominio.GetNotifications().Select(n => n.Value) };

            return _mapper.Map<ListaAmigosDto>(listaContato);
        }
    }
}
