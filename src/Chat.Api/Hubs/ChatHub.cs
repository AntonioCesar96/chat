using Chat.Application.Contatos.Interfaces;
using Chat.Application.ContatosStatus.Interfaces;
using Chat.Application.Mensagens.Interfaces;
using Chat.Domain.Mensagens.Dtos;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Chat.Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IContatoStatusRepositorioApplication _contatoStatusRepositorio;
        private readonly IArmazenadorDeMensagemApplication _armazenadorDeMensagem;
        private readonly IAtualizadorDeContatoStatusApplication _atualizadorDeContatoStatus;
        private readonly IRegistradorDeConexaoApplication _registradorDeConexao;
        private readonly IConsultaConnectionsDeAmigosApplication _consultaContatoStatusDeAmigos;
        private readonly IMarcadorDeMensagemLidaApplication _marcadorDeMensagemLida;

        public ChatHub(
            IContatoStatusRepositorioApplication contatoStatusRepositorio,
            IArmazenadorDeMensagemApplication armazenadorDeMensagem,
            IAtualizadorDeContatoStatusApplication atualizadorDeContatoStatus,
            IRegistradorDeConexaoApplication registradorDeConexao,
            IConsultaConnectionsDeAmigosApplication consultaContatoStatusDeAmigos,
            IMarcadorDeMensagemLidaApplication marcadorDeMensagemLida)
        {
            _contatoStatusRepositorio = contatoStatusRepositorio;
            _armazenadorDeMensagem = armazenadorDeMensagem;
            _atualizadorDeContatoStatus = atualizadorDeContatoStatus;
            _registradorDeConexao = registradorDeConexao;
            _consultaContatoStatusDeAmigos = consultaContatoStatusDeAmigos;
            _marcadorDeMensagemLida = marcadorDeMensagemLida;
        }

        public async Task RegistrarConexao(int contatoId)
        {
            var ids = await _registradorDeConexao.Registrar(contatoId, Context.ConnectionId);
            await Clients.Clients(ids)
                .SendAsync("Deslogar", true);

            var connectionsContato = _consultaContatoStatusDeAmigos.Consultar(contatoId);
            await Clients.Clients(connectionsContato)
                .SendAsync("ReceberStatusContatoOnline", contatoId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var dto = await _atualizadorDeContatoStatus.AtualizarParaOffline(Context.ConnectionId);

            var connectionsContato = _consultaContatoStatusDeAmigos.Consultar(dto.ContatoId);
            await Clients.Clients(connectionsContato)
                .SendAsync("ReceberStatusContatoOffline", dto);

            await base.OnDisconnectedAsync(exception);
        }

        public async Task EnviarMensagem(MensagemDto dto)
        {
            var mensagemDto = await _armazenadorDeMensagem.Salvar(dto);

            var connectionsIds = _contatoStatusRepositorio.ObterConnectionsIdsPorContatosIds(dto);
            await Clients.Clients(connectionsIds)
                .SendAsync("ReceberMensagem", mensagemDto);
        }

        public async Task EnviarContatoDigitando(bool estaDigitando, int contatoAmigoId, int contatoQueEstaDigitandoId)
        {
            var connectionsIds = _contatoStatusRepositorio.ObterConnectionsIdsPorContatosIds(contatoAmigoId);
            await Clients.Clients(connectionsIds)
                .SendAsync("ReceberContatoDigitando", estaDigitando, contatoQueEstaDigitandoId);
        }

        public async Task MarcarMensagemComoLida(int mensagemId, int conversaId, int contatoRemetenteId)
        {
            await _marcadorDeMensagemLida.MarcarMensagemComoLida(conversaId, mensagemId);

            var connectionsIds = _contatoStatusRepositorio.ObterConnectionsIdsPorContatosIds(contatoRemetenteId);
            await Clients.Clients(connectionsIds).SendAsync("ReceberMensagemLida", mensagemId, conversaId);
        }

        public async Task SendMessageToGroup(string groupName, string methodName, string message)
        {
            await Clients.Group(groupName).SendAsync(methodName, message);
        }
    }
}
