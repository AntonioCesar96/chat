using Chat.Domain.Contatos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Domain.Conversas.Entities
{
    public class Conversa
    {
        public int Id { get; private set; }
        public int ContatoCriadorDaConversaId { get; private set; }
        public virtual Contato ContatoCriadorDaConversa { get; private set; }
        public int ContatoId { get; private set; }
        public virtual Contato Contato { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public virtual IList<Mensagem> Mensagens { get; private set; } = new List<Mensagem>();

        public Conversa() { }

        public Conversa(
            int contatoCriadorDaConversaId,
            int contatoId)
        {
            ContatoCriadorDaConversaId = contatoCriadorDaConversaId;
            ContatoId = contatoId;
            DataCriacao = DateTime.Now;
        }
    }
}
