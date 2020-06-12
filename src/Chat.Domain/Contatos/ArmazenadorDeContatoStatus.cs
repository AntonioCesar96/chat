using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Entities;
using Chat.Domain.Contatos.Interfaces;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos
{
    public class ArmazenadorDeContatoStatus : DomainService, IArmazenadorDeContatoStatus
    {
        private readonly IContatoStatusRepositorio _contatoStatusRepositorio;

        public ArmazenadorDeContatoStatus(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IContatoStatusRepositorio contatoStatusRepositorio) : base(notificacaoDeDominio)
        {
            _contatoStatusRepositorio = contatoStatusRepositorio;
        }

        public async Task<ContatoStatus> Salvar(int contatoId, string connectionId)
        {
            ContatoStatus contatoStatus = CriarContatoStatus(contatoId, connectionId);

            await _contatoStatusRepositorio.Salvar(contatoStatus);
            return contatoStatus;
        }

        private ContatoStatus CriarContatoStatus(int contatoId, string connectionId)
        {
            return new ContatoStatus(contatoId, connectionId);
        }
    }
}
