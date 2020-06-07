using System.Collections.Generic;

namespace Chat.Domain.Common
{
    public class ResultadoDaConsulta
    {
        public int Total { get; set; }
        public int Pagina { get; set; }
        public int TotalPorPagina { get; set; }
        public IEnumerable<object> Lista { get; set; }

        public ResultadoDaConsulta() { }
    }
}
