using Chat.Application.Contatos.Interfaces;
using Chat.Application.ContatosStatus.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chat.Api.Hubs
{
    public class ConexaoHub
    {
        private readonly IHubContext<ChatHub, IChatCliente> _hubContext;
        private readonly IAtualizadorDeContatoStatusApplication _atualizadorDeContatoStatus;
        private readonly IRegistradorDeConexaoApplication _registradorDeConexao;
        private readonly IConsultaConnectionsDeAmigosApplication _consultaContatoStatusDeAmigos;

        public ConexaoHub(
            IHubContext<ChatHub, IChatCliente> hubContext,
            IAtualizadorDeContatoStatusApplication atualizadorDeContatoStatus,
            IRegistradorDeConexaoApplication registradorDeConexao,
            IConsultaConnectionsDeAmigosApplication consultaContatoStatusDeAmigos)
        {
            _hubContext = hubContext;
            _atualizadorDeContatoStatus = atualizadorDeContatoStatus;
            _registradorDeConexao = registradorDeConexao;
            _consultaContatoStatusDeAmigos = consultaContatoStatusDeAmigos;
        }

        public async Task RegistrarConexao(string connectionId, int contatoId)
        {
            var ids = await _registradorDeConexao.Registrar(contatoId, connectionId);
            await _hubContext.Clients.Clients(ids).Deslogar();

            var connectionsContato = _consultaContatoStatusDeAmigos.Consultar(contatoId);
            await _hubContext.Clients.Clients(connectionsContato)
                .ReceberStatusContatoOnline(contatoId);
        }

        public async Task Desconectar(string connectionId)
        {
            var dto = await _atualizadorDeContatoStatus.AtualizarParaOffline(connectionId);

            var connectionsContato = _consultaContatoStatusDeAmigos.Consultar(dto.ContatoId);
            await _hubContext.Clients.Clients(connectionsContato)
                .ReceberStatusContatoOffline(dto);
        }
    }
}
