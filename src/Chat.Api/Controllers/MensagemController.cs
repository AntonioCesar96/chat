using Chat.Application.Conversas.Interfaces;
using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Conversas.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagemController : BaseController
    {
        private readonly IArmazenadorDeMensagemApplication _armazenadorDeMensagem;
        private readonly IConsultaMensagemApplication _consultaMensagens;

        public MensagemController(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IArmazenadorDeMensagemApplication armazenadorDeMensagem,
            IConsultaMensagemApplication consultaMensagens) : base(notificacaoDeDominio)
        {
            _armazenadorDeMensagem = armazenadorDeMensagem;
            _consultaMensagens = consultaMensagens;
        }

        [HttpPost]
        public async Task<ActionResult> Salvar([FromBody] MensagemDto dto)
        {
            var mensagem = await _armazenadorDeMensagem.Salvar(dto);

            if (!OperacaoValida()) return BadRequestResponse();
            return Ok(mensagem);
        }

        [HttpGet]
        public ActionResult<ResultadoDaConsulta> ObterMensagens([FromQuery] MensagemFiltroDto filtro)
        {
            return _consultaMensagens.ObterMensagens(filtro);
        }
    }
}
