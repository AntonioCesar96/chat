using Chat.Application.Conversas.Interfaces;
using Chat.Domain.Common;
using Chat.Domain.Conversas.Dto;
using Chat.Domain.Conversas.Interfaces;

namespace Chat.Application.ListaContato
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
            var resultado = _consultaMensagens.ObterMensagens(filtro);
            return resultado;
        }
    }
}
