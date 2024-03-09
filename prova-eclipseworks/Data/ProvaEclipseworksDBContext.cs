using Microsoft.EntityFrameworkCore;
using prova_eclipseworks.Domain.Models;

namespace prova_eclipseworks.Data
{
    public class ProvaEclipseworksDBContext(DbContextOptions<ProvaEclipseworksDBContext> options) : DbContext(options)
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
