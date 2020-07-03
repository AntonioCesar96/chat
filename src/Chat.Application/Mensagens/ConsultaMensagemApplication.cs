using Chat.Application.Mensagens.Interfaces;
using Chat.Domain.Common;
using Chat.Domain.Mensagens.Dtos;
using Chat.Domain.Mensagens.Interfaces;

namespace Chat.Application.Mensagens
{
    public class ConsultaMensagemApplication : IConsultaMensagemApplication
    {
        private readonly IConsultaMensagem _consultaMensagens;

        public ConsultaMensagemApplication(IConsultaMensagem consultaMensagens)
        {
            _consultaMensagens = consultaMensagens;
        }

        public ResultadoDaConsulta ObterMensagens(MensagemFiltroDto filtro)
        {
            return _consultaMensagens.ObterMensagens(filtro);
        }
    }
}
