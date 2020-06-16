using Chat.Domain.Contatos.Dtos;
using System.Threading.Tasks;

namespace Chat.Application.Contatos.Interfaces
{
    public interface IArmazenadorDeContatoApplication
    {
        Task<ContatoDto> Salvar(ContatoDto dto);
    }
}
