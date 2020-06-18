using Chat.Domain.Common;

namespace Chat.Domain.Conversas.Dtos
{
    public class ConversaFiltroDto : Filtro
    {
        public int ContatoId { get; set; }
        public string NomeContato { get; set; }

        public ConversaFiltroDto()
        {
            Pagina = 1;
            TotalPorPagina = 10;
        }
    }
}
