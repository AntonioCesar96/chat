using Chat.Domain.Contatos.Dto;
using System.Threading.Tasks;

namespace Chat.Application.Contatos.Interfaces
{
    public interface IArmazenadorDeContatoApplication
    {
        Task<int> Salvar(ContatoDto dto);
    }
}
