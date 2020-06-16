using Chat.Domain.Contatos.Entidades;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos.Interfaces
{
    public interface IAutenticacaoContato
    {
        Task<Contato> Autenticar(string email, string senha);
    }
}
