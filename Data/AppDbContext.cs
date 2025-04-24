using Microsoft.EntityFrameworkCore;
using ProjetoDB.Models;

namespace ProjetoDB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Grafico> Graficos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Tarefa>().ToTable("Tarefas");
            modelBuilder.Entity<Grafico>().ToTable("Grafico");

            modelBuilder.Entity<Grafico>()
                .HasOne(g => g.Usuario)
                .WithOne()
                .HasForeignKey<Grafico>(g => g.Id_Usuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Usuario)
                .WithMany()
                .HasForeignKey(t => t.Id_Usuario)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
