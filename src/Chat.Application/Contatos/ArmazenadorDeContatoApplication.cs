using AutoMapper;
using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Contatos.Dtos;
using Chat.Domain.Contatos.Interfaces;
using System.Threading.Tasks;

namespace Chat.Application.Contatos
{
    public class ArmazenadorDeContatoApplication : IArmazenadorDeContatoApplication
    {
        private readonly IArmazenadorDeContato _armazenadorDeContato;
        private readonly IMapper _mapper;

        public ArmazenadorDeContatoApplication(
            IArmazenadorDeContato armazenadorDeContato,
            IMapper mapper)
        {
            _armazenadorDeContato = armazenadorDeContato;
            _mapper = mapper;
        }

        public async Task<ContatoDto> Salvar(ContatoCriacaoDto dto)
        {
            var contato = await _armazenadorDeContato.Salvar(dto);
            return _mapper.Map<ContatoDto>(contato);
        }
    }
}
