using Chat.Domain.ContatosStatus.Entidades;
using System.Threading.Tasks;

namespace Chat.Domain.ContatosStatus.Interfaces
{
    public interface IArmazenadorDeContatoStatus
    {
        Task<ContatoStatus> Salvar(int contatoId, string connectionId);
    }
}
