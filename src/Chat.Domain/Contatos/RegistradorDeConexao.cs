using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos
{
    public class RegistradorDeConexao : DomainService, IRegistradorDeConexao
    {
        private readonly IContatoStatusRepositorio _contatoStatusRepositorio;
        private readonly IArmazenadorDeContatoStatus _armazenadorDeContatoStatus;

        public RegistradorDeConexao(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IContatoStatusRepositorio contatoStatusRepositorio,
            IArmazenadorDeContatoStatus armazenadorDeContatoStatus) : base(notificacaoDeDominio)
        {
            _contatoStatusRepositorio = contatoStatusRepositorio;
            _armazenadorDeContatoStatus = armazenadorDeContatoStatus;
        }

        public async Task<List<string>> Registrar(int contatoId, string connectionId)
        {
            var ids = _contatoStatusRepositorio.ObterConnectionsIdsPorContatosIds(new List<int>() { contatoId });

            await _contatoStatusRepositorio.RemoverPorContato(contatoId);
            await _armazenadorDeContatoStatus.Salvar(contatoId, connectionId);

            return ids;
        }
    }
}
