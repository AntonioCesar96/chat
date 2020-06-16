using Chat.Domain.Common;
using Chat.Domain.ListaContatos.Dtos;

namespace Chat.Application.ListaContato.Interfaces
{
    public interface IConsultaListaContatoApplication
    {
        ResultadoDaConsulta ObterContatosAmigos(ListaContatoFiltroDto filtro);
    }
}
