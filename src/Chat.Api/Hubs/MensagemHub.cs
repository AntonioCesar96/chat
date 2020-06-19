using Chat.Application.ContatosStatus.Interfaces;
using Chat.Application.Mensagens.Interfaces;
using Chat.Domain.Mensagens.Dtos;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Api.Hubs
{
    public class MensagemHub
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IContatoStatusRepositorioApplication _contatoStatusRepositorio;
        private readonly IArmazenadorDeMensagemApplication _armazenadorDeMensagem;
        private readonly IMarcadorDeMensagemLidaApplication _marcadorDeMensagemLida;
        private readonly IConsultaMensagemApplication _consultaMensagens;

        public MensagemHub(
            IHubContext<ChatHub> hubContext,
            IContatoStatusRepositorioApplication contatoStatusRepositorio,
            IArmazenadorDeMensagemApplication armazenadorDeMensagem,
            IMarcadorDeMensagemLidaApplication marcadorDeMensagemLida,
            IConsultaMensagemApplication consultaMensagens)
        {
            _hubContext = hubContext;
            _contatoStatusRepositorio = contatoStatusRepositorio;
            _armazenadorDeMensagem = armazenadorDeMensagem;
            _marcadorDeMensagemLida = marcadorDeMensagemLida;
            _consultaMensagens = consultaMensagens;
        }

        public async Task EnviarMensagem(MensagemDto dto)
        {
            var mensagemDto = await _armazenadorDeMensagem.Salvar(dto);

            var connectionsIds = _contatoStatusRepositorio
                .ObterConnectionsIdsPorContatosIds(dto);

            if(dto.ConversaId == 0)
            {
                await _hubContext.Clients.Clients(connectionsIds)
                    .SendAsync("ReceberPrimeiraMensagem", mensagemDto);
                return;
            }

            await _hubContext.Clients.Clients(connectionsIds)
                .SendAsync("ReceberMensagem", mensagemDto);
        }

        public async Task EnviarContatoDigitando(bool estaDigitando, 
            int contatoAmigoId, int contatoQueEstaDigitandoId)
        {
            var connectionsIds = _contatoStatusRepositorio
                .ObterConnectionsIdsPorContatosIds(contatoAmigoId);

            await _hubContext.Clients.Clients(connectionsIds)
                .SendAsync("ReceberContatoDigitando", estaDigitando, contatoQueEstaDigitandoId);
        }

        public async Task MarcarMensagemComoLida(int mensagemId, 
            int conversaId, int contatoRemetenteId)
        {
            await _marcadorDeMensagemLida.MarcarMensagemComoLida(conversaId, mensagemId);

            var connectionsIds = _contatoStatusRepositorio
                .ObterConnectionsIdsPorContatosIds(contatoRemetenteId);

            await _hubContext.Clients.Clients(connectionsIds)
                .SendAsync("ReceberMensagemLida", mensagemId, conversaId);
        }

        public async Task ObterMensagens(MensagemFiltroDto filtro, string connectionId)
        {
            Thread.Sleep(500);
            var resultado = _consultaMensagens.ObterMensagens(filtro);

            await _hubContext.Clients.Client(connectionId)
                .SendAsync("ReceberMensagens", resultado);
        }
    }
}
