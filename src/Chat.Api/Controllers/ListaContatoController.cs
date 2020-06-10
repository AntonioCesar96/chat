using Chat.Application.ListaContato.Interfaces;
using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.ListaContatos.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chat.Api.Controllers
{
    [Route("api/lista-contato")]
    [ApiController]
    public class ListaContatoController : BaseController
    {
        private readonly IConsultaListaContatoApplication _consultaContatos;
        private readonly IArmazenadorContatoAmigoApplication _armazenadorContatoAmigo;

        public ListaContatoController(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IConsultaListaContatoApplication consultaContatos,
            IArmazenadorContatoAmigoApplication armazenadorContatoAmigo) : base(notificacaoDeDominio)
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
        public async Task<ActionResult> Salvar([FromBody] ContatoAmigoCriacaoDto dto)
        {
            var listaContato = await _armazenadorContatoAmigo.Salvar(dto);

            if (!OperacaoValida()) return ResponderErros();
            return Ok(listaContato);
        }
    }
}
