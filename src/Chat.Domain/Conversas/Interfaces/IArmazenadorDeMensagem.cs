using Chat.Domain.Conversas.Dto;
using System.Threading.Tasks;

namespace Chat.Domain.Conversas.Interfaces
{
    public interface IArmazenadorDeMensagem
    {
        Task<MensagemDto> Salvar(MensagemDto dto);
    }
}
