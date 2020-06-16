using Chat.Domain.Common;
using Chat.Domain.ListaContatos.Dtos;

namespace Chat.Domain.ListaContatos.Interfaces
{
    public interface IConsultaListaContato
    {
        ResultadoDaConsulta ObterContatosAmigos(ListaContatoFiltroDto filtro);
    }
}
