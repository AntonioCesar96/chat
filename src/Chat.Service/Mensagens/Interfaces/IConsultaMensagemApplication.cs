
using Chat.Domain.Common;
using Chat.Domain.Mensagens.Dtos;

namespace Chat.Application.Mensagens.Interfaces
{
    public interface IConsultaMensagemApplication
    {
        ResultadoDaConsulta ObterMensagens(MensagemFiltroDto filtro);
    }
}
