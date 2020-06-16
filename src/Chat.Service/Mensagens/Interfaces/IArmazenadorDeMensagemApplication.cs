using Chat.Domain.Mensagens.Dtos;
using System.Threading.Tasks;

namespace Chat.Application.Mensagens.Interfaces
{
    public interface IArmazenadorDeMensagemApplication
    {
        Task<MensagemDto> Salvar(MensagemDto dto);
    }
}
