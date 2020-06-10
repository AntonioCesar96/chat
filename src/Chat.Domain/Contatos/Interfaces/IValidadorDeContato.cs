using Chat.Domain.Contatos.Entities;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos.Interfaces
{
    public interface IValidadorDeContato
    {
        Task<bool> ValidarDominio(Contato contato);
        Task<bool> ValidarSeEmailJaExiste(string email);
        Task<bool> ValidarEmail(string email);
        Task<bool> ValidarSenha(string senha);
        Task<bool> ValidarSeContatoDiferenteDeNulo(Contato contato, string msg);
    }
}
