using System.Threading.Tasks;
using Chat.Application.ListaContato.Interfaces;
using Chat.Domain.ListaContatos.Dto;
using Chat.Domain.ListaContatos.Interfaces;

namespace Chat.Application.ListaContato
{
    public class ArmazenadorContatoAmigoApplication : IArmazenadorContatoAmigoApplication
    {
        private readonly IArmazenadorContatoAmigo _armazenadorContatoAmigo;

        public ArmazenadorContatoAmigoApplication(IArmazenadorContatoAmigo armazenadorContatoAmigo)
        {
            _armazenadorContatoAmigo = armazenadorContatoAmigo;
        }

        public async Task<int> Salvar(ContatoAmigoCriacaoDto dto)
        {
            var id = await _armazenadorContatoAmigo.Salvar(dto);
            return id;
        }
    }
}
