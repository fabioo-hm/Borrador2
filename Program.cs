using ColombianCoffeeApp.src.Modules.Usuarios.Application;
using ColombianCoffeeApp.src.Modules.Usuarios.Infrastructure.Repositories;
using ColombianCoffeeApp.src.Modules.Variedades.UI;
using ColombianCoffeeApp.src.Modules.Usuarios.UI;
using ColombianCoffeeApp.src.Shared.Context;
using Shared.Helpers;
using BorradoColombianCoffee.src.Modules.Usuarios.Domain;

internal class Program
{
    private static void Main(string[] args)
    {
        using var db = DbContextFactory.Create();
        var repoUsuarios = new RepositorioUsuarios(db);
        var serviceUsuarios = new UsuarioService(repoUsuarios);

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
            """
        );
        string opcion = Console.ReadLine() ?? "";
        string nombreUsuario = "";
        string contrasena = "";

        if (opcion == "1")
        {
            Console.Write("\nUsuario: ");
            nombreUsuario = Console.ReadLine() ?? "";
            Console.Write("Contraseña: ");
            contrasena = Console.ReadLine() ?? "";

            var usuario = serviceUsuarios.Login(nombreUsuario, contrasena);
            if (usuario == null)
            {
                Console.WriteLine("❌ Usuario o contraseña incorrectos.");
                return;
            }

            MostrarMenuPorRol(usuario.Rol);
        }
        else if (opcion == "2")
        {
            Console.Write("\nNuevo usuario: ");
            nombreUsuario = Console.ReadLine() ?? "";
            Console.Write("Contraseña: ");
            contrasena = Console.ReadLine() ?? "";

            Console.Write("Rol (Administrador/Usuario): ");
            string rol = Console.ReadLine() ?? "";

            serviceUsuarios.CrearUsuario(nombreUsuario, contrasena, rol);
            Console.WriteLine("✅ Usuario creado. Inicie sesión para continuar.");
        }
        else if (opcion == "3")
        {
            Console.WriteLine("👋 ¡Hasta luego!");
            return;
        }
        else
        {
            Console.WriteLine("❌ Opción inválida.");
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
                ║ 3.- Salir                              ║
                ╚════════════════════════════════════════╝
                Seleccione la opción: 
            """
            );
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
                    salir = true;
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
                ║ 2.- Salir                            ║
                ╚══════════════════════════════════════╝
                Seleccione la opción: 
            """
            );
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
                    salir = true;
                    break;
                default:
                    Console.WriteLine("❌ Opción inválida.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
