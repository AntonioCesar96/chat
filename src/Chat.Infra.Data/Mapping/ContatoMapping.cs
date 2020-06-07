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
            builder.Property(f => f.Email).IsRequired().HasMaxLength(50);
            builder.Property(f => f.Nome).IsRequired().HasMaxLength(50);
            builder.Property(f => f.Descricao).HasMaxLength(250);
            builder.Property(f => f.FotoUrl).HasMaxLength(250);

            builder.ToTable(nameof(Contato));
        }
    }
}
