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
        private readonly IAtualizadorDeContatoStatusApplication _atualizadorDeContatoStatusApplication;

        public ChatHub(
            IArmazenadorDeContatoStatusApplication armazenadorDeContatoStatus,
            IContatoStatusRepositorio contatoStatusRepositorio,
            IArmazenadorDeMensagemApplication armazenadorDeMensagem,
            IAtualizadorDeContatoStatusApplication atualizadorDeContatoStatusApplication)
        {
            _armazenadorDeContatoStatus = armazenadorDeContatoStatus;
            _contatoStatusRepositorio = contatoStatusRepositorio;
            _armazenadorDeMensagem = armazenadorDeMensagem;
            _atualizadorDeContatoStatusApplication = atualizadorDeContatoStatusApplication;
        }

        public async Task RegistrarConexao(int contatoId, string connectionId)
        {
            var ids = _contatoStatusRepositorio.ObterConnectionsIdsPorContatosIds(new List<int>() { contatoId });
            await Clients.Clients(ids).SendAsync("Deslogar", true); // parar back e rodar denovo validar front connectionId old

            await _contatoStatusRepositorio.RemoverPorContato(contatoId);
            var dto = await _armazenadorDeContatoStatus.Salvar(contatoId, Context.ConnectionId);

            var connectionsIds = _contatoStatusRepositorio.ObterConnectionsIdsPorContatosIds(new List<int>() { contatoId });
            await Clients.Clients(connectionsIds).SendAsync("ReceberStatusContato", dto);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var contatoStatusDto = await _atualizadorDeContatoStatusApplication.AtualizarParaOffline(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task EnviarMensagem(MensagemDto dto)
        {
            var mensagemDto = await _armazenadorDeMensagem.Salvar(dto);

            var contatosIds = new List<int>() { dto.ContatoRemetenteId, dto.ContatoDestinatarioId };
            var connectionsIds = _contatoStatusRepositorio.ObterConnectionsIdsPorContatosIds(contatosIds);

            await Clients.Clients(connectionsIds).SendAsync("ReceberMensagem", mensagemDto);
        }

        public async Task EnviarContatoDigitando(bool estaDigitando, int contatoAmigoId, int contatoQueEstaDigitandoId)
        {
            var connectionsIds = _contatoStatusRepositorio.ObterConnectionsIdsPorContatosIds(new List<int>() { contatoAmigoId });

            await Clients.Clients(connectionsIds).SendAsync("ReceberContatoDigitando", estaDigitando, contatoQueEstaDigitandoId);
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
