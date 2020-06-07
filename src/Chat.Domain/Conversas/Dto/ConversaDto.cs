using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.Conversas.Dto
{
    public class ConversaDto
    {
        public int Id { get; set; }
        public int ContatoUmId { get; set; }
        public int ContatoDoisId { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}
