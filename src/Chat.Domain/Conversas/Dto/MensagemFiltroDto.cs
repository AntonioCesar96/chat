using Chat.Domain.Common;

namespace Chat.Domain.Conversas.Dto
{
    public class MensagemFiltroDto : Filtro
    {
        public int ConversaId { get; set; }
        public int QtdMensagensPular { get; set; }
        public bool PrimeiraBusca { get; set; }

        public MensagemFiltroDto()
        {
            Pagina = 1;
            TotalPorPagina = 10;
        }
    }
}
