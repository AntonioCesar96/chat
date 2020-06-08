using Chat.Domain.Conversas.Dto;
using System.Threading.Tasks;

namespace Chat.Application.Conversas.Interfaces
{
    public interface IArmazenadorDeMensagemApplication
    {
        Task<MensagemDto> Salvar(MensagemDto dto);
    }
}
