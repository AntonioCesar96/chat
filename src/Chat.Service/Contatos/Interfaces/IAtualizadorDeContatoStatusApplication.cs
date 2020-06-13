using Chat.Domain.Contatos.Dto;
using System.Threading.Tasks;

namespace Chat.Application.Contatos.Interfaces
{
    public interface IAtualizadorDeContatoStatusApplication
    {
        Task<ContatoStatusDto> AtualizarParaOffline(string connectionId);
    }
}
