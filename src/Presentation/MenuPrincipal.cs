using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Variedades.Application;
using ColombianCoffeeApp.src.Modules.Variedades.Infrastructure.Repositories;
using ColombianCoffeeApp.src.Modules.Variedades.UI;
using ColombianCoffeeApp.src.Modules.Variedades.Domain.Entities;
using Shared.Helpers;
using ColombianCoffeeApp.src.Modules.Usuarios.Infrastructure.Repositories;
using ColombianCoffeeApp.src.Modules.Usuarios.UI;
using ColombianCoffeeApp.src.Modules.Usuarios.Application;

namespace ColombianCoffeeApp.src.Presentation
{
    public class MenuPrincipal
    {
        public void Mostrar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== COLOMBIAN COFFEE ☕ ===");
                Console.WriteLine("1. Explorar variedades (Cliente)");
                Console.WriteLine("2. Ingresar como Administrador");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuExploracion();
                        break;
                    case "2":
                        MenuAdministrador();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Presione una tecla...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void MenuExploracion()
        {
            using (var db = DbContextFactory.Create())
            {
                var repoVariedades = new RepositorioVariedades(db);
                var serviceVariedades = new VariedadService(repoVariedades);
                var menuExploracion = new MenuExploracion(serviceVariedades);
                menuExploracion.Mostrar();
            }
        }

        private void MenuAdministrador()
        {
            using (var db = DbContextFactory.Create())
            {
                var repoUsuarios = new RepositorioUsuarios(db);
                var serviceUsuarios = new UsuarioService(repoUsuarios);
                var menuAdmin = new MenuAdmin(serviceUsuarios);
                menuAdmin.Mostrar();
            }
        }
    }
}