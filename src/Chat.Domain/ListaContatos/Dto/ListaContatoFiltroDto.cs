using Chat.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.ListaContatos.Dto
{
    public class ListaContatoFiltroDto : Filtro
    {
        public int ContatoPrincipalId { get; set; }

        public ListaContatoFiltroDto()
        {
            Pagina = 1;
            TotalPorPagina = 10;
        }
    }
}
