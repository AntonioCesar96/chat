using Chat.Application.Contatos.Interfaces;
using Chat.Application.Conversas.Interfaces;
using Chat.Domain.Contatos.Interfaces;
using Chat.Domain.Conversas.Dto;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
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

        public ChatHub(
            IContatoStatusRepositorioApplication contatoStatusRepositorio,
            IArmazenadorDeMensagemApplication armazenadorDeMensagem,
            IAtualizadorDeContatoStatusApplication atualizadorDeContatoStatus,
            IRegistradorDeConexaoApplication registradorDeConexao,
            IConsultaConnectionsDeAmigosApplication consultaContatoStatusDeAmigos)
        {
            _contatoStatusRepositorio = contatoStatusRepositorio;
            _armazenadorDeMensagem = armazenadorDeMensagem;
            _atualizadorDeContatoStatus = atualizadorDeContatoStatus;
            _registradorDeConexao = registradorDeConexao;
            _consultaContatoStatusDeAmigos = consultaContatoStatusDeAmigos;
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

        public async Task SendMessageToGroup(string groupName, string methodName, string message)
        {
            await Clients.Group(groupName).SendAsync(methodName, message);
        }
    }
}
