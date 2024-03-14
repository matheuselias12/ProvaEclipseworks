using Microsoft.EntityFrameworkCore;
using prova_eclipseworks.Data.Mapping;
using prova_eclipseworks.Domain.Models;

namespace prova_eclipseworks.Data
{
    public class ProvaEclipseworksDBContext(DbContextOptions<ProvaEclipseworksDBContext> options) : DbContext(options)
    {
        //public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<HistoricoTarefa> HistoricoTarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrojetoMap());
            //modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            modelBuilder.ApplyConfiguration(new HistoricoTarefaMap());
        }
    }
}
