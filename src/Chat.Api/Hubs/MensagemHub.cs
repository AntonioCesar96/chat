using Chat.Application.ContatosStatus.Interfaces;
using Chat.Application.Mensagens.Interfaces;
using Chat.Domain.Mensagens.Dtos;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chat.Api.Hubs
{
    public class MensagemHub
    {
        private readonly IHubContext<ChatHub, IChatCliente> _hubContext;
        private readonly IContatoStatusRepositorioApplication _contatoStatusRepositorio;
        private readonly IArmazenadorDeMensagemApplication _armazenadorDeMensagem;
        private readonly IMarcadorDeMensagemLidaApplication _marcadorDeMensagemLida;

        public MensagemHub(
            IHubContext<ChatHub, IChatCliente> hubContext,
            IContatoStatusRepositorioApplication contatoStatusRepositorio,
            IArmazenadorDeMensagemApplication armazenadorDeMensagem,
            IMarcadorDeMensagemLidaApplication marcadorDeMensagemLida)
        {
            _hubContext = hubContext;
            _contatoStatusRepositorio = contatoStatusRepositorio;
            _armazenadorDeMensagem = armazenadorDeMensagem;
            _marcadorDeMensagemLida = marcadorDeMensagemLida;
        }

        public async Task EnviarMensagem(MensagemDto dto)
        {
            var mensagemDto = await _armazenadorDeMensagem.Salvar(dto);

            var connectionsIds = _contatoStatusRepositorio
                .ObterConnectionsIdsPorContatosIds(dto);

            await _hubContext.Clients.Clients(connectionsIds)
                .ReceberMensagem(mensagemDto);
        }

        public async Task EnviarContatoDigitando(bool estaDigitando, 
            int contatoAmigoId, int contatoQueEstaDigitandoId)
        {
            var connectionsIds = _contatoStatusRepositorio
                .ObterConnectionsIdsPorContatosIds(contatoAmigoId);

            await _hubContext.Clients.Clients(connectionsIds)
                .ReceberContatoDigitando(estaDigitando, contatoQueEstaDigitandoId);
        }

        public async Task MarcarMensagemComoLida(int mensagemId, 
            int conversaId, int contatoRemetenteId)
        {
            await _marcadorDeMensagemLida.MarcarMensagemComoLida(conversaId, mensagemId);

            var connectionsIds = _contatoStatusRepositorio
                .ObterConnectionsIdsPorContatosIds(contatoRemetenteId);

            await _hubContext.Clients.Clients(connectionsIds)
                .ReceberMensagemLida(mensagemId, conversaId);
        }
    }
}
