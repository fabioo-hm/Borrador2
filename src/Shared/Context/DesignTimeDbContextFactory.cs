using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ColombianCoffeeApp.src.Shared.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // ⚠️ Usa aquí la misma cadena de conexión que tengas en appsettings.json
            var connectionString = "server=127.0.0.1;database=ColombianCoffeeApp;user=root;password=Fabioandres2007;";

            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
