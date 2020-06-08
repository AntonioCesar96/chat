using Chat.Application.Conversas.Interfaces;
using Chat.Domain.Common;
using Chat.Domain.Conversas.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chat.Api.Controllers
{
    [Route("api/mensagem")]
    [ApiController]
    public class MensagemController : ControllerBase
    {
        private readonly IArmazenadorDeMensagemApplication _armazenadorDeMensagem;
        private readonly IConsultaMensagemApplication _consultaMensagens;

        public MensagemController(
            IArmazenadorDeMensagemApplication armazenadorDeMensagem,
            IConsultaMensagemApplication consultaMensagens)
        {
            _armazenadorDeMensagem = armazenadorDeMensagem;
            _consultaMensagens = consultaMensagens;
        }

        [HttpPost]
        public async Task<MensagemDto> Post([FromBody] MensagemDto dto)
        {
            return await _armazenadorDeMensagem.Salvar(dto);
        }

        [HttpGet]
        public ActionResult<ResultadoDaConsulta> ObterMensagens([FromQuery] MensagemFiltroDto filtro)
        {
            return _consultaMensagens.ObterMensagens(filtro);
        }
    }
}
