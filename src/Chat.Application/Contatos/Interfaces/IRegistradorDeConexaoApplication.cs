using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Application.Contatos.Interfaces
{
    public interface IRegistradorDeConexaoApplication
    {
        Task<List<string>> Registrar(int contatoId, string connectionId);
    }
}
