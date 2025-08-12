using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ColombianCoffeeApp.src.Shared.Context;

namespace ColombianCoffeeApp.src.Shared.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = "server=127.0.0.1;database=ColombianCoffeeApp;user=root;password=Fabioandres2007;";
            
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 0)));
            
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
