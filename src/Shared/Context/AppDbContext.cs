using Microsoft.EntityFrameworkCore;
using ColombianCoffeeApp.src.Modules.Variedades.Domain.Entities;
using ColombianCoffeeApp.src.Modules.Usuarios.Domain.Entities;

namespace ColombianCoffeeApp.src.Shared.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<VariedadCafe> Variedades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}

