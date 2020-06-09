using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Entities;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos.Interfaces
{
    public interface IContatoRepositorio
    {
        Task Salvar(Contato contato);
        Contato ObterPorEmail(string email);
        Contato ObterPorEmailSenha(string email, string senha);
    }
}
