using Chat.Domain.Common;
using Chat.Domain.Contatos.Entities;
using FluentValidation;
using System;

namespace Chat.Domain.Conversas.Entities
{
    public class Mensagem : BaseEntity<int, Mensagem>
    {
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

        public override bool Validar()
        {
            RuleFor(p => p.ConversaId)
                .GreaterThan(0)
                .WithMessage(ChatResources.MsgInformeConversa);

            RuleFor(p => p.ContatoRemetenteId)
                .GreaterThan(0)
                .WithMessage(ChatResources.MsgInformeContatoRemetente); 

            RuleFor(p => p.ContatoDestinatarioId)
                .GreaterThan(0)
                .WithMessage(ChatResources.MsgInformeContatoDestinatario);

            RuleFor(p => p.MensagemEnviada)
                .NotEmpty()
                .NotNull()
                .WithMessage(ChatResources.MsgInformeMensagem);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
