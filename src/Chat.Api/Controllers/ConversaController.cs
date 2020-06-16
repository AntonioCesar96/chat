using Chat.Application.Conversas.Interfaces;
using Chat.Domain.Common;
using Chat.Domain.Conversas.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [Route("api/conversa")]
    [ApiController]
    public class ConversaController : ControllerBase
    {
        private readonly IConsultaConversaApplication _consultaConversas;

        public ConversaController(
            IConsultaConversaApplication consultaConversas)
        {
            _consultaConversas = consultaConversas;
        }

        [HttpGet]
        public ActionResult<ResultadoDaConsulta> ObterConversasDoContato(
            [FromQuery] ConversaFiltroDto filtro)
        {
            return _consultaConversas.ObterConversasDoContato(filtro);
        }
    }
}
