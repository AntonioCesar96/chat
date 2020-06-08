using Chat.Domain.Contatos.Entities;
using System;

namespace Chat.Domain.Conversas.Entities
{
    public class Mensagem
    {
        public int Id { get; private set; }
        public int ConversaId { get; private set; }
        public virtual Conversa Conversa { get; private set; }
        public int ContatoId { get; private set; }
        public virtual Contato Contato { get; private set; }
        public string MensagemEnviada { get; private set; }
        public DateTime DataEnvio { get; private set; }

        public Mensagem() { }
    }
}
