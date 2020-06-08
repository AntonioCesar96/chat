using Chat.Application.ListaContato.Interfaces;
using Chat.Domain.Common;
using Chat.Domain.ListaContatos.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [Route("api/lista-contato")]
    [ApiController]
    public class ListaContatoController : ControllerBase
    {
        private readonly IConsultaListaContatoApplication _consultaContatos;

        public ListaContatoController(
            IConsultaListaContatoApplication consultaContatos)
        {
            _consultaContatos = consultaContatos;
        }

        [HttpGet]
        public ActionResult<ResultadoDaConsulta> ObterListaDeContatos(
            [FromQuery] ListaContatoFiltroDto filtro)
        {
            return _consultaContatos.ObterContatosAmigos(filtro);
        }
    }
}
