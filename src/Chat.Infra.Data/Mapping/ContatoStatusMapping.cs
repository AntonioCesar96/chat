using Chat.Domain.Contatos.Entities;
using Chat.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Infra.Data.Mapping
{
    public class ContatoStatusMapping : EntityTypeConfiguration<ContatoStatus>
    {
        public override void Map(EntityTypeBuilder<ContatoStatus> builder)
        {
            builder.Property(s => s.ConnectionId).IsRequired();
            builder.Property(s => s.Online).IsRequired();
            builder.Property(s => s.Data).IsRequired();

            builder.Property(s => s.ContatoId).IsRequired();
            builder.HasOne(s => s.Contato)
                .WithMany()
                .HasForeignKey(s => s.ContatoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(s => s.CascadeMode);
            builder.Ignore(s => s.ValidationResult);

            builder.ToTable(nameof(ContatoStatus));
        }
    }
}
