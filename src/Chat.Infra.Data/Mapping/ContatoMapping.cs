using Chat.Domain.Contatos.Entities;
using Chat.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Infra.Data.Mapping
{
    public class ContatoMapping : EntityTypeConfiguration<Contato>
    {
        public override void Map(EntityTypeBuilder<Contato> builder)
        {
            builder.Property(s => s.Nome).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Email).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Senha).IsRequired().HasMaxLength(250);
            builder.Property(s => s.Descricao).HasMaxLength(250);
            builder.Property(s => s.FotoUrl);

            builder.Ignore(s => s.CascadeMode);
            builder.Ignore(s => s.ValidationResult);

            builder.ToTable(nameof(Contato));
        }
    }
}
