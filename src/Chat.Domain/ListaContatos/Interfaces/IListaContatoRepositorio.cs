using Chat.Domain.ListaContatos.Entidades;
using System.Threading.Tasks;

namespace Chat.Domain.ListaContatos.Interfaces
{
    public interface IListaContatoRepositorio
    {
        Task Salvar(ListaContato contato);
        ListaContato ObterPorListaContato(ListaContato listaContato);
    }
}
