using Chat.Domain.ContatosStatus.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Domain.ContatosStatus.Interfaces
{
    public interface IContatoStatusRepositorio
    {
        Task Salvar(ContatoStatus contato);
        ContatoStatus ObterPorContato(int contatoId);
        IQueryable<ContatoStatus> ObterPorContatosIds(List<int> contatosIds);
        List<string> ObterConnectionsIdsPorContatosIds(List<int> contatosIds);
        ContatoStatus ObterPorConnection(string connectionId);
        Task RemoverPorContato(int contatoId);
        Task RemoverPorConnection(string connectionId);
        Task Atualizar(ContatoStatus contatoStatus);
    }
}
