using ColombianCoffeeApp.src.Modules.Usuarios.Application;
using ColombianCoffeeApp.src.Modules.Usuarios.Infrastructure.Repositories;
using ColombianCoffeeApp.src.Presentation;
using Microsoft.EntityFrameworkCore.Internal;
using Shared.Helpers;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var db = DbContextFactory.Create())
        {
            var repoUsuarios = new RepositorioUsuarios(db);
            var serviceUsuarios = new UsuarioService(repoUsuarios);

            // Solo si no existe el admin
            var adminExistente = serviceUsuarios.Login("admin", "1234");
            if (adminExistente == null)
            {
                serviceUsuarios.RegistrarAdmin("admin", "1234");
                Console.WriteLine("✅ Admin creado con usuario: admin y contraseña: 1234");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        // MENÚ PRINCIPAL
        var menu = new MenuPrincipal();
        menu.Mostrar();
    }
}