
using Chat.Domain.Common;
using FluentValidation;

namespace Chat.Domain.Contatos.Entities
{
    public class Contato : BaseEntity<int, Contato>
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Descricao { get; private set; }
        public string FotoUrl { get; private set; }

        public Contato() { }

        public Contato(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public override bool Validar()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage(ChatResources.MsgInformeNomeDoContato);

            RuleFor(p => p.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(ChatResources.MsgInformeEmailDoContato);

            RuleFor(p => p.Senha)
                .NotEmpty()
                .NotNull()
                .WithMessage(ChatResources.MsgInformeSenhaDoContato);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
