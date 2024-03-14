using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Domain.Enums;

namespace prova_eclipseworks.Data.Mapping
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");

            builder.HasKey(p => p.TarefaId);

            builder.Property(p => p.ProjetoId)
                   .HasColumnType("int");

            builder.Property(p => p.Titulo)
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                   .HasColumnType("varchar(500)");

            builder.Property(p => p.DataVencimento)
                   .HasColumnType("datetime");
            
            builder.Property(p => p.StatusTarefa)
                   .HasColumnType("int"); 
            
            builder.Property(p => p.Prioridades)
                   .HasColumnType("int");

            builder.HasOne(p => p.Projeto)
                   .WithMany()
                   .HasForeignKey(p => p.ProjetoId);
        }
    }
}
