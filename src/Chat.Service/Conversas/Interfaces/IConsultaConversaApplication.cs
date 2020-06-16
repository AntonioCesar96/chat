using Chat.Domain.Common;
using Chat.Domain.Conversas.Dtos;

namespace Chat.Application.Conversas.Interfaces
{
    public interface IConsultaConversaApplication
    {
        ResultadoDaConsulta ObterConversasDoContato(ConversaFiltroDto filtro);
    }
}
