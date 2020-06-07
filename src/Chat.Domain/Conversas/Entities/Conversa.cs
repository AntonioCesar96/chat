using Chat.Domain.Contatos.Entities;
using System;

namespace Chat.Domain.Conversas.Entities
{
    public class Conversa
    {
        public int Id { get; private set; }
        public int ContatoUmId { get; private set; }
        public virtual Contato ContatoUm { get; private set; }
        public int ContatoDoisId { get; private set; }
        public virtual Contato ContatoDois { get; private set; }
        public string Mensagem { get; private set; }
        public DateTime DataEnvio { get; private set; }

        public Conversa() { }
    }
}
