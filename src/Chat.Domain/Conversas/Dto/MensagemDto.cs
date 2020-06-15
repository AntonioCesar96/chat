using Chat.Domain.Contatos.Entities;
using Chat.Domain.Conversas.Enums;
using System;

namespace Chat.Domain.Conversas.Dto
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
