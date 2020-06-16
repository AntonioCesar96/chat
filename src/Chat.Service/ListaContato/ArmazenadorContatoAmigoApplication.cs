using System.Threading.Tasks;
using AutoMapper;
using Chat.Application.ListaContato.Interfaces;
using Chat.Domain.ListaContatos.Dtos;
using Chat.Domain.ListaContatos.Interfaces;

namespace Chat.Application.ListaContato
{
    public class ArmazenadorContatoAmigoApplication : IArmazenadorContatoAmigoApplication
    {
        private readonly IArmazenadorContatoAmigo _armazenadorContatoAmigo;
        private readonly IMapper _mapper;

        public ArmazenadorContatoAmigoApplication(
            IArmazenadorContatoAmigo armazenadorContatoAmigo,
            IMapper mapper)
        {
            _armazenadorContatoAmigo = armazenadorContatoAmigo;
            _mapper = mapper;
        }

        public async Task<ListaContatoDto> Salvar(ContatoAmigoCriacaoDto dto)
        {
            var listaContato = await _armazenadorContatoAmigo.Salvar(dto);
            return _mapper.Map<ListaContatoDto>(listaContato);
        }
    }
}
