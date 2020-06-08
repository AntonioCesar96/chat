using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Interfaces;
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

        public async Task<int> Salvar(ContatoDto dto)
        {
            var id = await _armazenadorDeContato.Salvar(dto);
            return id;
        }
    }
}
