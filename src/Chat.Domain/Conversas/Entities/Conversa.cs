using Chat.Domain.Common;
using Chat.Domain.Contatos.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Chat.Domain.Conversas.Entities
{
    public class Conversa : BaseEntity<int, Conversa>
    {
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

        public override bool Validar()
        {
            RuleFor(p => p.ContatoCriadorDaConversaId)
                .GreaterThan(0)
                .WithMessage(ChatResources.MsgInformeContatoRemetente);

            RuleFor(p => p.ContatoId)
                .GreaterThan(0)
                .WithMessage(ChatResources.MsgInformeContatoDestinatario);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
