using Chat.Application.Conversas.Interfaces;
using Chat.Domain.Conversas.Dto;
using Chat.Domain.Conversas.Interfaces;
using Chat.Infra.Util.AutoMapper;
using System.Threading.Tasks;

namespace Chat.Application.Conversas
{
    public class ArmazenadorDeMensagemApplication : IArmazenadorDeMensagemApplication
    {
        private readonly IArmazenadorDeMensagem _armazenadorMensagem;

        public ArmazenadorDeMensagemApplication(IArmazenadorDeMensagem armazenadorMensagem)
        {
            _armazenadorMensagem = armazenadorMensagem;
        }

        public async Task<MensagemDto> Salvar(MensagemDto dto)
        {
            var mensagem = await _armazenadorMensagem.Salvar(dto);
            return mensagem.MapTo<MensagemDto>();
        }
    }
}