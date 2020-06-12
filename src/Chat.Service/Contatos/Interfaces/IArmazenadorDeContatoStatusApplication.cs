using Chat.Domain.Contatos.Dto;
using System.Threading.Tasks;

namespace Chat.Application.Contatos.Interfaces
{
    public interface IArmazenadorDeContatoStatusApplication
    {
        Task<ContatoStatusDto> Salvar(int contatoId, string connectionId);
    }
}
