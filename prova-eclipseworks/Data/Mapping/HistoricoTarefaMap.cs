using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Domain.Enums;

namespace prova_eclipseworks.Data.Mapping
{
    public class HistoricoTarefaMap : IEntityTypeConfiguration<HistoricoTarefa>
    {
        public void Configure(EntityTypeBuilder<HistoricoTarefa> builder)
        {
            builder.ToTable("HistoricoTarefa");

            builder.HasKey(p => p.TarefaHistoricoId);

            builder.Property(p => p.DataModificacao)
                   .HasColumnType("datetime");

            builder.Property(p => p.InfoModidicada)
                   .HasColumnType("varchar(800)");

            builder.Property(p => p.Comentario)
                   .HasColumnType("varchar(500)");

            builder.HasOne(p => p.Tarefa)
                   .WithMany()
                   .HasForeignKey(p => p.TarefaId);
        }
    }
}
