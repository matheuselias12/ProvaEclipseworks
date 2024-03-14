using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using prova_eclipseworks.Domain.Models;

namespace prova_eclipseworks.Data.Mapping
{
    public class TrojetoMap : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("Projeto");

            builder.HasKey(p => p.ProjetoId);

            builder.Property(p => p.UsuarioId)
                   .HasColumnType("int");

            builder.Property(p => p.NomeProjeto)
                   .HasColumnType("varchar(500)");

            builder.Property(p => p.StatusProjeto)
                   .HasColumnType("int");
        }
    }
}
