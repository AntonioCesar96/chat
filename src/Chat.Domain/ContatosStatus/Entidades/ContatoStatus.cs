using Chat.Domain.Common;
using Chat.Domain.Contatos.Entidades;
using FluentValidation;
using System;

namespace Chat.Domain.ContatosStatus.Entidades
{
    public class ContatoStatus : BaseEntity<int, ContatoStatus>
    {
        public int ContatoId { get; private set; }
        public virtual Contato Contato { get; private set; }
        public string ConnectionId { get; private set; }
        public bool Online { get; private set; }
        public DateTime Data { get; private set; }

        public ContatoStatus() { }

        public ContatoStatus(int contatoId, string connectionId)
        {
            ContatoId = contatoId;
            ConnectionId = connectionId;
            Online = true;
            Data = DateTime.Now;
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

        public void AlterarData(DateTime data)
        {
            Data = data;
        }

        public void AlterarOnline(bool online)
        {
            Online = online;
        }
    }
}
