using Chat.Domain.Mensagens.Enums;
using System;

namespace Chat.Domain.Mensagens.Dtos
{
    public class MensagemDto
    {
        public int MensagemId { get; set; }
        public int ConversaId { get; set; }
        public int ContatoRemetenteId { get; set; }
        public int ContatoDestinatarioId { get; set; }
        public string MensagemEnviada { get; set; }
        public DateTime DataEnvio { get; set; }
        public StatusMensagem StatusMensagem { get; set; }

    }
}
