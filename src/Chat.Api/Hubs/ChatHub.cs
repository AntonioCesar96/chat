using Chat.Domain.Conversas.Dtos;
using Chat.Domain.ListaContatos.Dtos;
using Chat.Domain.Mensagens.Dtos;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Chat.Api.Hubs
{
    public class ChatHub : Hub<IChatCliente>
    {
        private readonly MensagemHub _mensagemHub;
        private readonly ConexaoHub _conexaoHub;
        private readonly ConversasHub _conversasHub;
        private readonly ContatoHub _contatoHub;

        public ChatHub(
            ConexaoHub conexaoHub,
            MensagemHub mensagemHub,
            ConversasHub conversasHub,
            ContatoHub contatoHub)
        {
            _conexaoHub = conexaoHub;
            _mensagemHub = mensagemHub;
            _conversasHub = conversasHub;
            _contatoHub = contatoHub;
        }

        public async Task RegistrarConexao(int contatoId)
        {
            await _conexaoHub.RegistrarConexao(Context.ConnectionId, contatoId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await _conexaoHub.Desconectar(Context.ConnectionId);

            await base.OnDisconnectedAsync(exception);
        }

        public async Task ObterStatusDoContato(int contatoId)
        {
            await _conexaoHub.ObterStatusDoContato(Context.ConnectionId, contatoId);
        }

        public async Task EnviarMensagem(MensagemDto dto)
        {
            await _mensagemHub.EnviarMensagem(dto);
        }

        public async Task EnviarContatoDigitando(bool estaDigitando, int contatoAmigoId, int contatoQueEstaDigitandoId)
        {
            await _mensagemHub.EnviarContatoDigitando(estaDigitando, contatoAmigoId, contatoQueEstaDigitandoId);
        }

        public async Task MarcarMensagemComoLida(int mensagemId, int conversaId, int contatoRemetenteId)
        {
            await _mensagemHub.MarcarMensagemComoLida(mensagemId, conversaId, contatoRemetenteId);
        }

        public async Task ObterConversasDoContato(ConversaFiltroDto filtro)
        {
            await _conversasHub.ObterConversasDoContato(filtro, Context.ConnectionId);
        }

        public async Task ObterConversasDoContatoPesquisa(ConversaFiltroDto filtro)
        {
            await _conversasHub.ObterConversasDoContatoPesquisa(filtro, Context.ConnectionId);
        }

        public async Task ObterMensagens(MensagemFiltroDto filtro)
        {
            await _mensagemHub.ObterMensagens(filtro, Context.ConnectionId);
        }

        public async Task ObterContatosAmigosPesquisa(ListaContatoFiltroDto filtro)
        {
            await _contatoHub.ObterContatosAmigosPesquisa(filtro, Context.ConnectionId);
        }
    }
}
