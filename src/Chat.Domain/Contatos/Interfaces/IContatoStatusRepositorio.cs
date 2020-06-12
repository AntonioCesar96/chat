using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos.Interfaces
{
    public interface IContatoStatusRepositorio
    {
        Task Salvar(ContatoStatus contato);
        ContatoStatus ObterPorContato(int contatoId);
        List<string> ObterConnectionsIdsPorContatosIds(List<int> contatosIds);
        ContatoStatus ObterPorConnection(string connectionId);
        Task RemoverPorConnection(string connectionId);
    }
}
