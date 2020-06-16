using Chat.Domain.ContatosStatus.Entidades;
using System.Threading.Tasks;

namespace Chat.Domain.ContatosStatus.Interfaces
{
    public interface IAtualizadorDeContatoStatus
    {
        Task<ContatoStatus> AtualizarParaOffline(string connectionId);
    }
}
