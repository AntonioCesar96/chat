using System.Threading.Tasks;
using Chat.Application.ListaContato.Interfaces;
using Chat.Domain.ListaContatos.Dtos;
using Chat.Domain.ListaContatos.Interfaces;
using Chat.Infra.Util.AutoMapper;

namespace Chat.Application.ListaContato
{
    public class ArmazenadorContatoAmigoApplication : IArmazenadorContatoAmigoApplication
    {
        private readonly IArmazenadorContatoAmigo _armazenadorContatoAmigo;

        public ArmazenadorContatoAmigoApplication(IArmazenadorContatoAmigo armazenadorContatoAmigo)
        {
            _armazenadorContatoAmigo = armazenadorContatoAmigo;
        }

        public async Task<ListaContatoDto> Salvar(ContatoAmigoCriacaoDto dto)
        {
            var listaContato = await _armazenadorContatoAmigo.Salvar(dto);
            return listaContato.MapTo<ListaContatoDto>();
        }
    }
}
