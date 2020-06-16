using Chat.Domain.Common;
using Chat.Domain.Contatos.Entidades;
using FluentValidation;

namespace Chat.Domain.ListaContatos.Entidades
{
    public class ListaContato : BaseEntity<int, ListaContato>
    {
        public int ContatoPrincipalId { get; private set; }
        public virtual Contato ContatoPrincipal { get; private set; }
        public int ContatoAmigoId { get; private set; }
        public virtual Contato ContatoAmigo { get; private set; }

        public ListaContato() { }

        public ListaContato(
            int contatoPrincipalId,
            int contatoAmigoId)
        {
            ContatoPrincipalId = contatoPrincipalId;
            ContatoAmigoId = contatoAmigoId;
        }

        public override bool Validar()
        {
            RuleFor(p => p.ContatoPrincipalId)
                .GreaterThan(0)
                .WithMessage(ChatResources.MsgInformeContatoPrincipal);

            RuleFor(p => p.ContatoAmigoId)
                .GreaterThan(0)
                 .WithMessage(ChatResources.MsgInformeContatoAmigo);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
