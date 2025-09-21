using AuthApi.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Repositorios
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<CategoriaFM> Categorias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Email único
            modelBuilder.Entity<Usuarios>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Relación 1 Rol -> N Usuarios
            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId);

            modelBuilder.Entity<CategoriaFM>().ToTable("CategoriaFM");

        }
    }
}
