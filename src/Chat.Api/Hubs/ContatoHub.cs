using Chat.Application.ListaContato.Interfaces;
using Chat.Domain.ListaContatos.Dtos;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chat.Api.Hubs
{
    public class ContatoHub
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IConsultaListaContatoApplication _consultaContatos;

        public ContatoHub(
            IHubContext<ChatHub> hubContext,
            IConsultaListaContatoApplication consultaContatos)
        {
            _hubContext = hubContext;
            _consultaContatos = consultaContatos;
        }

        public async Task ObterContatosAmigosPesquisa(ListaContatoFiltroDto filtro,
            string connectionId)
        {
            var resultado = _consultaContatos.ObterContatosAmigos(filtro);

            await _hubContext.Clients.Client(connectionId)
                .SendAsync("ReceberContatosAmigosPesquisa", resultado);
        }
    }
}
