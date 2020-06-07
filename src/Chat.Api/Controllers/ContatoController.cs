using System.Threading.Tasks;
using Chat.Domain.Common;
using Chat.Domain.Contatos.Dto;
using Chat.Domain.ListaContatos.Dto;
using Chat.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet]
        public ActionResult<ResultadoDaConsulta> ObterListaDeContatos([FromQuery] ListaContatoFiltroDto filtro)
        {
            return _contatoService.ObterListaDeContatos(filtro);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<int> Post([FromBody] ContatoDto dto)
        {
            return await _contatoService.Salvar(dto);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
