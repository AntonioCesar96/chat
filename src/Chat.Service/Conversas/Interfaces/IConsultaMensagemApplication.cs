
using Chat.Domain.Common;
using Chat.Domain.Conversas.Dto;

namespace Chat.Application.Conversas.Interfaces
{
    public interface IConsultaMensagemApplication
    {
        ResultadoDaConsulta ObterMensagens(MensagemFiltroDto filtro);
    }
}
