using Chat.Application.Mensagens.Interfaces;
using Chat.Domain.Mensagens.Dtos;
using Chat.Domain.Mensagens.Interfaces;
using Chat.Infra.Util.AutoMapper;
using System.Threading.Tasks;

namespace Chat.Application.Mensagens
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