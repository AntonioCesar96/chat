using System.Threading.Tasks;
using Chat.Api.Jwt;
using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : BaseController
    {
        private readonly TokenService _tokenService;
        private readonly IArmazenadorDeContatoApplication _armazenadorDeContato;
        private readonly IAutenticacaoContatoApplication _autenticacaoContato;
        private readonly IContatoRepositorioApplication _contatoRepositorio;
        private readonly ITokenManager _tokenManager;

        public ContatoController(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IArmazenadorDeContatoApplication armazenadorDeContato,
            IAutenticacaoContatoApplication autenticacaoContato,
            IContatoRepositorioApplication contatoRepositorio,
            TokenService tokenService,
            ITokenManager tokenManager) : base(notificacaoDeDominio)
        {
            _armazenadorDeContato = armazenadorDeContato;
            _autenticacaoContato = autenticacaoContato;
            _tokenService = tokenService;
            _contatoRepositorio = contatoRepositorio;
            _tokenManager = tokenManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Salvar([FromBody] ContatoDto dto)
        {
            var contato = await _armazenadorDeContato.Salvar(dto);
            if (!OperacaoValida()) return ResponderErros();

            return Ok(contato);
        }

        [HttpPost("{email}/{senha}")]
        [AllowAnonymous]
        public async Task<ActionResult> Autenticar(string email, string senha)
        {
            var contato = await _autenticacaoContato.Autenticar(email, senha);
            if (!OperacaoValida()) return ResponderErros();

            var token = _tokenService.GenerateToken(contato);
            return Ok(new { contato, token });
        }

        [HttpGet("{email}")]
        [Authorize]
        public ActionResult ObterContato(string email)
        {
            var contato = _contatoRepositorio.ObterPorEmail(email);
            return Ok(contato);
        }

        [HttpPost("desconectar")]
        [Authorize]
        public async Task<IActionResult> Desconectar()
        {
            await _tokenManager.DeactivateCurrentAsync();
            return Ok(true);
        }
    }
}
