using Chat.Domain.Contatos.Entities;
using System;

namespace Chat.Domain.Conversas.Entities
{
    public class Mensagem
    {
        public int Id { get; private set; }
        public int ConversaId { get; private set; }
        public virtual Conversa Conversa { get; private set; }
        public int ContatoRemetenteId { get; private set; }
        public virtual Contato ContatoRemetente { get; private set; }
        public int ContatoDestinatarioId { get; private set; }
        public virtual Contato ContatoDestinatario { get; private set; }
        public string MensagemEnviada { get; private set; }
        public DateTime DataEnvio { get; private set; }

        public Mensagem() { }

        public Mensagem(
            int conversaId,
            int contatoRemetenteId,
            int contatoDestinatarioId,
            string mensagemEnviada
            )
        {
            ConversaId = conversaId;
            ContatoRemetenteId = contatoRemetenteId;
            ContatoDestinatarioId = contatoDestinatarioId;
            MensagemEnviada = mensagemEnviada;
            DataEnvio = DateTime.Now;
        }
    }
}
