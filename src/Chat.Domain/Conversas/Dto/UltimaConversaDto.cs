using System;

namespace Chat.Domain.Conversas.Dto
{
    public class UltimaConversaDto
    {
        public int ConversaId { get; set; }
        public int ContatoAmigoId { get; set; }
        public string UltimaMensagem { get; set; }
        public int ContatoRemetenteId { get; set; }
        public int ContatoDestinatarioId { get; set; }
        public DateTime DataEnvio { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string FotoUrl { get; set; }
    }
}
