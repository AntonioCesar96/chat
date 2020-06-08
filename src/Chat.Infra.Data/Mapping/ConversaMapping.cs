using Chat.Domain.Conversas.Entities;
using Chat.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Infra.Data.Mapping
{
    public class ConversaMapping : EntityTypeConfiguration<Conversa>
    {
        public override void Map(EntityTypeBuilder<Conversa> builder)
        {
            builder.Property(s => s.ContatoUmId).IsRequired();
            builder.HasOne(s => s.ContatoUm)
                .WithMany()
                .HasForeignKey(_ => _.ContatoUmId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.ContatoDoisId).IsRequired();
            builder.HasOne(s => s.ContatoDois)
                .WithMany()
                .HasForeignKey(_ => _.ContatoDoisId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(f => f.DataCriacao).IsRequired();

            builder.ToTable(nameof(Conversa));
        }
    }
}
