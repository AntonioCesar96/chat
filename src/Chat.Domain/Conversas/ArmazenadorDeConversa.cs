using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Conversas.Entities;
using Chat.Domain.Conversas.Interfaces;
using System.Threading.Tasks;

namespace Chat.Domain.Conversas
{
    public class ArmazenadorDeConversa : DomainService, IArmazenadorDeConversa
    {
        private readonly IConversaRepositorio _conversaRepositorio;

        public ArmazenadorDeConversa(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IConversaRepositorio conversaRepositorio) : base(notificacaoDeDominio)
        {
            _conversaRepositorio = conversaRepositorio;
        }

        public async Task<Conversa> Salvar(int contatoRemetenteId, int contatoDestinatarioId)
        {
            Conversa conversa = CriarConversa(contatoRemetenteId, contatoDestinatarioId);

            if (!await ValidarSeConversaEstaValido(conversa)) return null;

            await _conversaRepositorio.Salvar(conversa);
            return conversa;
        }

        private Conversa CriarConversa(int contatoRemetenteId, int contatoDestinatarioId)
        {
            return new Conversa(contatoRemetenteId, contatoDestinatarioId);
        }

        private async Task<bool> ValidarSeConversaEstaValido(Conversa conversa)
        {
            if (conversa.Validar()) return true;

            await NotificarValidacoesDeDominio(conversa.ValidationResult);
            return false;
        }
    }
}
