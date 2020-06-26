using Chat.Application.Contatos.Interfaces;
using Chat.Application.ListaContato.Interfaces;
using Chat.Domain.Contatos.Dtos;
using Chat.Domain.ListaContatos.Dtos;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chat.Api.Hubs
{
    public class ContatoHub
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IConsultaListaContatoApplication _consultaContatos;
        private readonly IAtualizadorDeContatoApplication _atualizadorDeContato;

        public ContatoHub(
            IHubContext<ChatHub> hubContext,
            IConsultaListaContatoApplication consultaContatos,
            IAtualizadorDeContatoApplication atualizadorDeContato)
        {
            _hubContext = hubContext;
            _consultaContatos = consultaContatos;
            _atualizadorDeContato = atualizadorDeContato;
        }

        public async Task ObterContatosAmigosPesquisa(ListaContatoFiltroDto filtro,
            string connectionId)
        {
            var resultado = _consultaContatos.ObterContatosAmigos(filtro);

            await _hubContext.Clients.Client(connectionId)
                .SendAsync("ReceberContatosAmigosPesquisa", resultado);
        }

        public async Task ObterTodosOsContatosAmigos(ListaContatoFiltroDto filtro,
            string connectionId)
        {
            var resultado = _consultaContatos.ObterContatosAmigos(filtro);

            await _hubContext.Clients.Client(connectionId)
                .SendAsync("ReceberTodosOsContatosAmigos", resultado);
        }

        public async Task AtualizarDadosContato(ContatoDto dto)
        {
            await _atualizadorDeContato.Atualizar(dto);
        }
    }
}
