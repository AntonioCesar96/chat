using AutoMapper;
using Chat.Application.Mensagens.Interfaces;
using Chat.Domain.Mensagens.Dtos;
using Chat.Domain.Mensagens.Interfaces;
using System.Threading.Tasks;

namespace Chat.Application.Mensagens
{
    public class ArmazenadorDeMensagemApplication : IArmazenadorDeMensagemApplication
    {
        private readonly IArmazenadorDeMensagem _armazenadorMensagem;
        private readonly IMapper _mapper;

        public ArmazenadorDeMensagemApplication(
            IArmazenadorDeMensagem armazenadorMensagem,
            IMapper mapper)
        {
            _armazenadorMensagem = armazenadorMensagem;
            _mapper = mapper;
        }

        public async Task<MensagemDto> Salvar(MensagemDto dto)
        {
            var mensagem = await _armazenadorMensagem.Salvar(dto);

            if (dto.ConversaId == 0)
                return _mapper.Map<MensagemContatosDto>(mensagem);
            return _mapper.Map<MensagemDto>(mensagem);
        }
    }
}