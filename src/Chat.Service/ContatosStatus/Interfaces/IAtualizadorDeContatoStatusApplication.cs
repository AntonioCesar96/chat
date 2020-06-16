using Chat.Domain.ContatosStatus.Dtos;
using System.Threading.Tasks;

namespace Chat.Application.ContatosStatus.Interfaces
{
    public interface IAtualizadorDeContatoStatusApplication
    {
        Task<ContatoStatusDto> AtualizarParaOffline(string connectionId);
    }
}
