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
        private readonly IArmazenadorDeContatoStatusApplication _armazenadorDeContatoStatus;
        private readonly IContatoStatusRepositorio _contatoStatusRepositorio;
        private readonly IArmazenadorDeMensagemApplication _armazenadorDeMensagem;

        public ChatHub(
            IArmazenadorDeContatoStatusApplication armazenadorDeContatoStatus,
            IContatoStatusRepositorio contatoStatusRepositorio,
            IArmazenadorDeMensagemApplication armazenadorDeMensagem)
        {
            _armazenadorDeContatoStatus = armazenadorDeContatoStatus;
            _contatoStatusRepositorio = contatoStatusRepositorio;
            _armazenadorDeMensagem = armazenadorDeMensagem;
        }

        public async Task RegistrarConexao(int contatoId, string connectionId)
        {
            await _contatoStatusRepositorio.RemoverPorConnection(connectionId);
            await _armazenadorDeContatoStatus.Salvar(contatoId, Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await _contatoStatusRepositorio.RemoverPorConnection(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task EnviarMensagem(MensagemDto dto)
        {
            var mensagemDto = await _armazenadorDeMensagem.Salvar(dto);

            var contatosIds = new List<int>() { dto.ContatoRemetenteId, dto.ContatoDestinatarioId };
            var connectionsIds = _contatoStatusRepositorio.ObterConnectionsIdsPorContatosIds(contatosIds);

            await Clients.Clients(connectionsIds).SendAsync("ReceberMensagem", mensagemDto);
        }

        public async Task SendToAllAsync(string methodName, string message)
        {
            await Clients.All.SendAsync(methodName, message);
        }

        public async Task SendMessageToGroup(string groupName, string methodName, string message)
        {
            await Clients.Group(groupName).SendAsync(methodName, message);
        }
    }
}
