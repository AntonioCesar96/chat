
using Chat.Domain.Common;
using FluentValidation;

namespace Chat.Domain.Contatos.Entities
{
    public class ContatoStatus : BaseEntity<int, ContatoStatus>
    {
        public int ContatoId { get; private set; }
        public virtual Contato Contato { get; private set; }
        public string ConnectionId { get; private set; }

        public ContatoStatus() { }

        public ContatoStatus(int contatoId, string connectionId)
        {
            ContatoId = contatoId;
            ConnectionId = connectionId;
        }

        public override bool Validar()
        {
            RuleFor(p => p.ContatoId)
                .GreaterThan(0);

            RuleFor(p => p.ConnectionId)
                .NotEmpty()
                .NotNull();

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
