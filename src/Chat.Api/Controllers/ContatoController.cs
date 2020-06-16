using System.Threading.Tasks;
using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : BaseController
    {
        private readonly IArmazenadorDeContatoApplication _armazenadorDeContato;
        private readonly IAutenticacaoContatoApplication _autenticacaoContato;

        public ContatoController(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IArmazenadorDeContatoApplication armazenadorDeContato,
            IAutenticacaoContatoApplication autenticacaoContato) : base(notificacaoDeDominio)
        {
            _armazenadorDeContato = armazenadorDeContato;
            _autenticacaoContato = autenticacaoContato;
        }

        [HttpPost]
        public async Task<ActionResult> Salvar([FromBody] ContatoDto dto)
        {
            var contato = await _armazenadorDeContato.Salvar(dto);

            if (!OperacaoValida()) return ResponderErros();
            return Ok(contato);
        }

        [HttpGet("{email}/{senha}")]
        public async Task<ActionResult> Autenticar(string email, string senha)
        {
            var contato = await _autenticacaoContato.Autenticar(email, senha);

            if (!OperacaoValida()) return ResponderErros();
            return Ok(contato);
        }
    }
}
