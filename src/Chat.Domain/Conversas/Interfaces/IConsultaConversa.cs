using Chat.Domain.Common;
using Chat.Domain.Conversas.Dtos;

namespace Chat.Domain.Conversas.Interfaces
{
    public interface IConsultaConversa
    {
        ResultadoDaConsulta ObterConversasDoContato(ConversaFiltroDto filtro);
    }
}
