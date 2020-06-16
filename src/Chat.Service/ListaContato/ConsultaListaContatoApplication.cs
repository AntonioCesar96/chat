using Chat.Application.ListaContato.Interfaces;
using Chat.Domain.Common;
using Chat.Domain.ListaContatos.Dtos;
using Chat.Domain.ListaContatos.Interfaces;

namespace Chat.Application.ListaContato
{
    public class ConsultaListaContatoApplication : IConsultaListaContatoApplication
    {
        private readonly IConsultaListaContato _consultaContatos;

        public ConsultaListaContatoApplication(IConsultaListaContato consultaContatos)
        {
            _consultaContatos = consultaContatos;
        }

        public ResultadoDaConsulta ObterContatosAmigos(ListaContatoFiltroDto filtro)
        {
            var resultado = _consultaContatos.ObterContatosAmigos(filtro);
            return resultado;
        }
    }
}
