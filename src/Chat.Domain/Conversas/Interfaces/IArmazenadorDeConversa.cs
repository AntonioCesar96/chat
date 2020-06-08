using Chat.Domain.Conversas.Dto;
using Chat.Domain.Conversas.Entities;
using System.Threading.Tasks;

namespace Chat.Domain.Conversas.Interfaces
{
    public interface IArmazenadorDeConversa
    {
        Task<Conversa> Salvar(int contatoRemetenteId, int contatoDestinatarioId);
    }
}
