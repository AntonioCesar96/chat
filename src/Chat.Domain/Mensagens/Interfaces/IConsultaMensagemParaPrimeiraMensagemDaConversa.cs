using Chat.Domain.Common;
using Chat.Domain.Mensagens.Dtos;

namespace Chat.Domain.Mensagens.Interfaces
{
    public interface IConsultaMensagemParaPrimeiraMensagemDaConversa
    {
        MensagemContatosDto ObterMensagem(int mensagemId);
    }
}
