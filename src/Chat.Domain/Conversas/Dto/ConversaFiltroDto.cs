using Chat.Domain.Common;

namespace Chat.Domain.Conversas.Dto
{
    public class ConversaFiltroDto : Filtro
    {
        public int ContatoId { get; set; }

        public ConversaFiltroDto()
        {
            Pagina = 1;
            TotalPorPagina = 10;
        }
    }
}
