using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Interfaces;
using Chat.Infra.Util.AutoMapper;
using System.Threading.Tasks;

namespace Chat.Application.Contatos
{
    public class ArmazenadorDeContatoApplication : IArmazenadorDeContatoApplication
    {
        private readonly IArmazenadorDeContato _armazenadorDeContato;

        public ArmazenadorDeContatoApplication(IArmazenadorDeContato armazenadorDeContato)
        {
            _armazenadorDeContato = armazenadorDeContato;
        }

        public async Task<ContatoDto> Salvar(ContatoDto dto)
        {
            var contato = await _armazenadorDeContato.Salvar(dto);
            return contato.MapTo<ContatoDto>();
        }
    }
}
