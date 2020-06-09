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
                .HasForeignKey(s => s.ContatoPrincipalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.ContatoAmigoId).IsRequired();
            builder.HasOne(s => s.ContatoAmigo)
                .WithMany()
                .HasForeignKey(s => s.ContatoAmigoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(s => s.CascadeMode);
            builder.Ignore(s => s.ValidationResult);

            builder.ToTable(nameof(ListaContato));
        }
    }
}
