using Microsoft.EntityFrameworkCore;
using ColombianCoffeeApp.src.Modules.Variedades.Domain.Entities;
using ColombianCoffeeApp.src.Modules.Usuarios.Domain.Entities;

namespace ColombianCoffeeApp.src.Shared.Context
{
    public class AppDbContext : DbContext
    {
         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<VariedadCafe> Variedades => Set<VariedadCafe>();
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuario");
            modelBuilder.Entity<VariedadCafe>().ToTable("variedad");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}

