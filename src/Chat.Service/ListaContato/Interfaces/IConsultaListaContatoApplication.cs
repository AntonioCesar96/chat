using Chat.Domain.Common;
using Chat.Domain.ListaContatos.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Application.ListaContato.Interfaces
{
    public interface IConsultaListaContatoApplication
    {
        ResultadoDaConsulta ObterContatosAmigos(ListaContatoFiltroDto filtro);
    }
}
