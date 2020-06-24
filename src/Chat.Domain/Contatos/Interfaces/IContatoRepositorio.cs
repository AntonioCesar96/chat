using Chat.Domain.Contatos.Entidades;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos.Interfaces
{
    public interface IContatoRepositorio
    {
        Task Salvar(Contato contato);
        Contato ObterPorEmail(string email);
        Contato ObterPorEmailSenha(string email, string senha);
        Contato ObterPorId(int id);
    }
}
