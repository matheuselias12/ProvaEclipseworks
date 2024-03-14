using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prova_eclipseworks.Domain.Models;

namespace prova_eclipseworks.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(p => p.UsuarioId);

            builder.Property(p => p.Nome)
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Email)
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Telefone)
                   .HasColumnType("varchar(20)");

            builder.Property(p => p.Endereco)
                   .HasColumnType("varchar(100)");
        }
    }
}
