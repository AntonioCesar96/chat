
using Chat.Domain.Common;
using Chat.Domain.Conversas.Dto;

namespace Chat.Application.Conversas.Interfaces
{
    public interface IConsultaConversaApplication
    {
        ResultadoDaConsulta ObterConversasDoContato(ConversaFiltroDto filtro);
    }
}
