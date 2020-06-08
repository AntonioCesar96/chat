using Chat.Domain.Common;
using Chat.Domain.Conversas.Dto;

namespace Chat.Domain.Conversas.Interfaces
{
    public interface IConsultaMensagem
    {
        ResultadoDaConsulta ObterMensagens(MensagemFiltroDto filtro);
    }
}
