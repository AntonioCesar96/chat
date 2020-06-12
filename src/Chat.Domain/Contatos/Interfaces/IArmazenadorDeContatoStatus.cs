using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Entities;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos.Interfaces
{
    public interface IArmazenadorDeContatoStatus
    {
        Task<ContatoStatus> Salvar(int contatoId, string connectionId);
    }
}
