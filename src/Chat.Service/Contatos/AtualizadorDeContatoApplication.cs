using AutoMapper;
using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Contatos.Dtos;
using Chat.Domain.Contatos.Interfaces;
using System.Threading.Tasks;

namespace Chat.Application.Contatos
{
    public class AtualizadorDeContatoApplication : IAtualizadorDeContatoApplication
    {
        private readonly IAtualizadorDeContato _atualizadorDeContato;
        private readonly IMapper _mapper;

        public AtualizadorDeContatoApplication(
            IAtualizadorDeContato atualizadorDeContato,
            IMapper mapper)
        {
            _atualizadorDeContato = atualizadorDeContato;
            _mapper = mapper;
        }

        public async Task<ContatoDto> Atualizar(ContatoDto dto)
        {
            var contato = await _atualizadorDeContato.Atualizar(dto);
            return _mapper.Map<ContatoDto>(contato);
        }
    }
}
