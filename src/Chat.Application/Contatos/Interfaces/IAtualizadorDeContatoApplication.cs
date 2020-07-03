using Chat.Domain.Contatos.Dtos;
using System.Threading.Tasks;

namespace Chat.Application.Contatos.Interfaces
{
    public interface IAtualizadorDeContatoApplication
    {
        Task<ContatoDto> Atualizar(ContatoDto dto);
    }
}
