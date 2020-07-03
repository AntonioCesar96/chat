using Chat.Domain.Contatos.Dtos;
using System.Threading.Tasks;

namespace Chat.Application.Contatos.Interfaces
{
    public interface IAutenticacaoContatoApplication
    {
        Task<ContatoDto> Autenticar(string email, string senha);
    }
}
