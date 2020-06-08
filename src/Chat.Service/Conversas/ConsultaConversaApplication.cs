using Chat.Application.Contatos.Interfaces;
using Chat.Application.Conversas.Interfaces;
using Chat.Application.ListaContato.Interfaces;
using Chat.Domain.Common;
using Chat.Domain.Contatos.Interfaces;
using Chat.Domain.Conversas.Dto;
using Chat.Domain.Conversas.Interfaces;
using Chat.Domain.ListaContatos.Dto;
using Chat.Domain.ListaContatos.Interfaces;

namespace Chat.Application.ListaContato
{
    public class ConsultaConversaApplication : IConsultaConversaApplication
    {
        private readonly IConsultaConversa _consultaConversas;

        public ConsultaConversaApplication(IConsultaConversa consultaConversas)
        {
            _consultaConversas = consultaConversas;
        }

        public ResultadoDaConsulta ObterConversasDoContato(ConversaFiltroDto filtro)
        {
            var resultado = _consultaConversas.ObterConversasDoContato(filtro);
            return resultado;
        }
    }
}
