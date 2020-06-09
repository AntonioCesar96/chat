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
            builder.Property(s => s.ContatoCriadorDaConversaId).IsRequired();
            builder.HasOne(s => s.ContatoCriadorDaConversa)
                .WithMany()
                .HasForeignKey(s => s.ContatoCriadorDaConversaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.ContatoId).IsRequired();
            builder.HasOne(s => s.Contato)
                .WithMany()
                .HasForeignKey(s => s.ContatoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.DataCriacao).IsRequired();

            builder.Ignore(s => s.CascadeMode);
            builder.Ignore(s => s.ValidationResult);

            builder.ToTable(nameof(Conversa));
        }
    }
}
