using Chat.Domain.ListaContatos.Entities;
using Chat.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Infra.Data.Mapping
{
    public class ListaContatoMapping : EntityTypeConfiguration<ListaContato>
    {
        public override void Map(EntityTypeBuilder<ListaContato> builder)
        {
            builder.Property(s => s.ContatoPrincipalId).IsRequired();
            builder.HasOne(s => s.ContatoPrincipal)
                .WithMany()
                .HasForeignKey(_ => _.ContatoPrincipalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.ContatoAmigoId).IsRequired();
            builder.HasOne(s => s.ContatoAmigo)
                .WithMany()
                .HasForeignKey(_ => _.ContatoAmigoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(nameof(ListaContato));
        }
    }
}
