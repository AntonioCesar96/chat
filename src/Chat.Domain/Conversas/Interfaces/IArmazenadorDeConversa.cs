using Chat.Domain.Conversas.Entidades;
using System.Threading.Tasks;

namespace Chat.Domain.Conversas.Interfaces
{
    public interface IArmazenadorDeConversa
    {
        Task<Conversa> Salvar(int contatoRemetenteId, int contatoDestinatarioId);
    }
}
