using System;

namespace Chat.Domain.ContatosStatus.Dtos
{
    public class ContatoStatusDto
    {
        public int ContatoId { get; set; }
        public bool Online { get; set; }
        public DateTime Data { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
