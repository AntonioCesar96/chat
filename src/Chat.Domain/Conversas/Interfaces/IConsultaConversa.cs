using Chat.Domain.Common;
using Chat.Domain.Conversas.Dto;

namespace Chat.Domain.Conversas.Interfaces
{
    public interface IConsultaConversa
    {
        ResultadoDaConsulta ObterConversasDoContato(ConversaFiltroDto filtro);
    }
}
