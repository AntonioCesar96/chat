using Chat.Domain.Conversas.Entities;
using Chat.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Infra.Data.Mapping
{
    public class MensagemMapping : EntityTypeConfiguration<Mensagem>
    {
        public override void Map(EntityTypeBuilder<Mensagem> builder)
        {
            builder.Property(s => s.ConversaId).IsRequired();
            builder.HasOne(s => s.Conversa)
                .WithMany()
                .HasForeignKey(_ => _.ConversaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.ContatoId).IsRequired();
            builder.HasOne(s => s.Contato)
                .WithMany()
                .HasForeignKey(_ => _.ContatoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(f => f.MensagemEnviada).IsRequired();
            builder.Property(f => f.DataEnvio).IsRequired();

            builder.ToTable(nameof(Mensagem));
        }
    }
}
