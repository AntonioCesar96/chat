using Chat.Domain.Contatos.Entities;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos.Interfaces
{
    public interface IAtualizadorDeContatoStatus
    {
        Task<ContatoStatus> AtualizarParaOffline(string connectionId);
    }
}
