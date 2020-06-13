using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Entities;
using Chat.Domain.Contatos.Interfaces;
using System;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos
{
    public class AtualizadorDeContatoStatus : DomainService, IAtualizadorDeContatoStatus
    {
        private readonly IContatoStatusRepositorio _contatoStatusRepositorio;

        public AtualizadorDeContatoStatus(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IContatoStatusRepositorio contatoStatusRepositorio) : base(notificacaoDeDominio)
        {
            _contatoStatusRepositorio = contatoStatusRepositorio;
        }

        public async Task<ContatoStatus> AtualizarParaOffline(string connectionId)
        {
            var contatoStatus = _contatoStatusRepositorio.ObterPorConnection(connectionId);

            contatoStatus.AlterarOnline(false);
            contatoStatus.AlterarData(DateTime.Now);

            await _contatoStatusRepositorio.Atualizar(contatoStatus);
            return contatoStatus;
        }
    }
}
