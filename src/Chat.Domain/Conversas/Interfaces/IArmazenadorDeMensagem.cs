using Chat.Domain.Conversas.Dto;
using Chat.Domain.Conversas.Entities;
using System.Threading.Tasks;

namespace Chat.Domain.Conversas.Interfaces
{
    public interface IArmazenadorDeMensagem
    {
        Task<Mensagem> Salvar(MensagemDto dto);
    }
}
