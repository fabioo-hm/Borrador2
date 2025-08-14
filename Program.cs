using ColombianCoffeeApp.src.Modules.Usuarios.Application;
using ColombianCoffeeApp.src.Modules.Usuarios.Infrastructure.Repositories;
using ColombianCoffeeApp.src.Modules.Variedades.UI;
using ColombianCoffeeApp.src.Modules.Usuarios.UI;
using ColombianCoffeeApp.src.Shared.Context;
using Shared.Helpers;
using BorradoColombianCoffee.src.Modules.Usuarios.Domain;
using ColombianCoffeeApp.Services;
using System.Linq;
using ColombianCoffeeApp;


internal class Program
{
    private static void Main(string[] args)
    {
        using var db = DbContextFactory.Create();
        var repoUsuarios = new RepositorioUsuarios(db);
        DataSeeder.Seed(db);
        var serviceUsuarios = new UsuarioService(repoUsuarios);

        bool salirPrograma = false;

        while (!salirPrograma)
        {
            Console.Clear();
            Console.Write("""
            ╔════════════════════════════════════════════╗
            ║     ✨ BIENVENIDO A COLOMBIAN COFFEE ✨    ║
            ╚════════════════════════════════════════════╝
            ║ 1.- Iniciar Sesión                         ║
            ║ 2.- Crear Nueva Cuenta                     ║
            ║ 3.- Salir                                  ║
            ╚════════════════════════════════════════════╝
            Seleccione la opción: 
            """);

            string opcion = Console.ReadLine() ?? "";

            if (opcion == "1")
            {
                Console.Clear();
                Console.Write("Usuario: ");
                string nombreUsuario = Console.ReadLine() ?? "";
                Console.Write("Contraseña: ");
                string contrasena = Console.ReadLine() ?? "";

                var usuario = serviceUsuarios.Login(nombreUsuario, contrasena);
                if (usuario == null)
                {
                    Console.WriteLine("❌ Usuario o contraseña incorrectos.");
                    Console.ReadKey();
                }
                else
                {
                    // Ir al menú según el rol
                    MostrarMenuPorRol(usuario.Rol);
                }
            }
            else if (opcion == "2")
            {
                Console.Write("\nNuevo usuario: ");
                string nombreUsuario = Console.ReadLine() ?? "";
                Console.Write("Contraseña: ");
                string contrasena = Console.ReadLine() ?? "";
                Console.Write("Rol (Administrador/Usuario): ");
                string rol = Console.ReadLine() ?? "";

                serviceUsuarios.CrearUsuario(nombreUsuario, contrasena, rol);
                Console.WriteLine("✅ Usuario creado. Inicie sesión para continuar.");
                Console.ReadKey();
            }
            else if (opcion == "3")
            {
                Console.WriteLine("👋 ¡Hasta luego!");
                salirPrograma = true;
            }
            else
            {
                Console.WriteLine("❌ Opción inválida.");
                Console.ReadKey();
            }
        }
    }

    private static void MostrarMenuPorRol(RolUsuario rol)
    {
        if (rol == RolUsuario.Administrador)
            MenuAdmin();
        else
            MenuUsuario();
    }

    private static void MenuAdmin()
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.Write("""
            ╔════════════════════════════════════════╗
            ║        🔧 MENÚ ADMINISTRADOR 🔧        ║
            ╚════════════════════════════════════════╝
            ║ 1.- CRUD Variedades                    ║
            ║ 2.- CRUD Usuarios                      ║
            ║ 3.- Generar catálogo PDF               ║
            ║ 4.- Cerrar Sesión                      ║
            ╚════════════════════════════════════════╝
            Seleccione la opción: 
            """);
            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    new MenuVariedades().Mostrar();
                    break;
                case "2":
                    new MenuUsuarios().Mostrar();
                    break;
                case "3":
                    using (var db = DbContextFactory.Create())
                    {
                        var variedades = db.Variedades.ToList();
                        var pdfService = new PdfService();
                        pdfService.GenerarCatalogo(variedades, "catalogo.pdf");
                        Console.ReadKey();
                    }
                    break;
                case "4":
                    salir = true; // Volver al menú principal
                    break;
                default:
                    Console.WriteLine("❌ Opción inválida.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void MenuUsuario()
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.Write("""
            ╔══════════════════════════════════════╗
            ║          👤 MENÚ USUARIO 👤          ║
            ╚══════════════════════════════════════╝
            ║ 1.- Explorar Variedades              ║
            ║ 2.- Generar catálogo PDF             ║
            ║ 3.- Cerrar Sesión                    ║
            ╚══════════════════════════════════════╝
            Seleccione la opción: 
            """);
            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    using (var db = DbContextFactory.Create())
                    {
                        var repoVariedades = new ColombianCoffeeApp.src.Modules.Variedades.Infrastructure.Repositories.RepositorioVariedades(db);
                        var serviceVariedades = new ColombianCoffeeApp.src.Modules.Variedades.Application.VariedadService(repoVariedades);
                        new MenuExploracion(serviceVariedades).Mostrar();
                    }
                    break;
                case "2":
                    using (var db = DbContextFactory.Create())
                    {
                        var variedades = db.Variedades.ToList();
                        var pdfService = new PdfService();
                        pdfService.GenerarCatalogo(variedades, "catalogo.pdf");
                        Console.ReadKey();
                    }
                    break;
                case "3":
                    salir = true; // Volver al menú principal
                    break;
                default:
                    Console.WriteLine("❌ Opción inválida.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}