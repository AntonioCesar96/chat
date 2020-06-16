using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.ContatosStatus.Entidades;
using Chat.Domain.ContatosStatus.Interfaces;
using System;
using System.Threading.Tasks;

namespace Chat.Domain.ContatosStatus
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

            AtualizarParaOffline(contatoStatus);

            await _contatoStatusRepositorio.Atualizar(contatoStatus);
            return contatoStatus;
        }

        private void AtualizarParaOffline(ContatoStatus contatoStatus)
        {
            contatoStatus.AlterarOnline(false);
            contatoStatus.AlterarData(DateTime.Now);
        }
    }
}
