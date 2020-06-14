using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos.Interfaces
{
    public interface IRegistradorDeConexao
    {
        Task<List<string>> Registrar(int contatoId, string connectionId);
    }
}
