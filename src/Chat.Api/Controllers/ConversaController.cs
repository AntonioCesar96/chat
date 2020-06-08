using Chat.Application.ListaContato.Interfaces;
using Chat.Domain.Common;
using Chat.Domain.ListaContatos.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chat.Api.Controllers
{
    [Route("api/conversa")]
    [ApiController]
    public class ConversaController : ControllerBase
    {
        private readonly IConsultaListaContatoApplication _consultaContatos;
        private readonly IArmazenadorContatoAmigoApplication _armazenadorContatoAmigo;

        public ConversaController(
            IConsultaListaContatoApplication consultaContatos,
            IArmazenadorContatoAmigoApplication armazenadorContatoAmigo)
        {
            _consultaContatos = consultaContatos;
            _armazenadorContatoAmigo = armazenadorContatoAmigo;
        }

        [HttpGet]
        public ActionResult<ResultadoDaConsulta> ObterListaDeContatos(
            [FromQuery] ListaContatoFiltroDto filtro)
        {
            return _consultaContatos.ObterContatosAmigos(filtro);
        }

        [HttpPost]
        public async Task<int> Post([FromBody] ContatoAmigoCriacaoDto dto)
        {
            return await _armazenadorContatoAmigo.Salvar(dto);
        }
    }
}
