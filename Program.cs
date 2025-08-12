using ColombianCoffeeApp.src.Modules.Usuarios.Application;
using ColombianCoffeeApp.src.Modules.Usuarios.Infrastructure.Repositories;
using ColombianCoffeeApp.src.Presentation;
using ColombianCoffeeApp.src.Shared.Context;
using Shared.Helpers;
using ColombianCoffeeApp; // Para DataSeeder

internal class Program
{
    private static void Main(string[] args)
    {
        using (var db = DbContextFactory.Create())
        {
            // 📌 Ejecutar seeder de variedades
            DataSeeder.Seed(db);

            // 📌 Crear admin si no existe
            var repoUsuarios = new RepositorioUsuarios(db);
            var serviceUsuarios = new UsuarioService(repoUsuarios);

            var adminExistente = serviceUsuarios.Login("admin", "1234");
            if (adminExistente == null)
            {
                serviceUsuarios.RegistrarAdmin("admin", "1234");
                Console.WriteLine("✅ Admin creado con usuario: admin y contraseña: 1234");
            }
            else
            {
                Console.WriteLine("ℹ️ Admin ya existe en la base de datos.");
            }
        }

        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();

        // MENÚ PRINCIPAL
        var menu = new MenuPrincipal();
        menu.Mostrar();
    }
}
