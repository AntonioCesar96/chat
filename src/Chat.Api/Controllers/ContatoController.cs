using System.Threading.Tasks;
using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Contatos.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IArmazenadorDeContatoApplication _armazenadorDeContato;

        public ContatoController(
            IArmazenadorDeContatoApplication armazenadorDeContato)
        {
            _armazenadorDeContato = armazenadorDeContato;
        }

        [HttpPost]
        public async Task<int> Post([FromBody] ContatoDto dto)
        {
            return await _armazenadorDeContato.Salvar(dto);
        }
    }
}
