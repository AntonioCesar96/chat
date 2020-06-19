using Chat.Application.Conversas.Interfaces;
using Chat.Domain.Conversas.Dtos;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chat.Api.Hubs
{
    public class ConversasHub
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IConsultaConversaApplication _consultaConversas;

        public ConversasHub(
            IHubContext<ChatHub> hubContext,
            IConsultaConversaApplication consultaConversas)
        {
            _hubContext = hubContext;
            _consultaConversas = consultaConversas;
        }

        public async Task ObterConversasDoContato(ConversaFiltroDto filtro, 
            string connectionId)
        {
            var resultado = _consultaConversas.ObterConversasDoContato(filtro);

            await _hubContext.Clients.Client(connectionId)
                .SendAsync("ReceberConversasDoContato", resultado);
        }
    }
}
