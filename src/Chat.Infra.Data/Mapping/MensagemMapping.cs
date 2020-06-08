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
                .WithMany(s => s.Mensagens)
                .HasForeignKey(s => s.ConversaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.ContatoRemetenteId).IsRequired();
            builder.HasOne(s => s.ContatoRemetente)
                .WithMany()
                .HasForeignKey(s => s.ContatoRemetenteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.ContatoDestinatarioId).IsRequired();
            builder.HasOne(s => s.ContatoDestinatario)
                .WithMany()
                .HasForeignKey(s => s.ContatoDestinatarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.MensagemEnviada).IsRequired();
            builder.Property(s => s.DataEnvio).IsRequired();

            builder.ToTable(nameof(Mensagem));
        }
    }
}
