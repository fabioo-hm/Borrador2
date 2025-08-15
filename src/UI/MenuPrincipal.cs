using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BorradoColombianCoffee.src.Modules.Usuarios.Domain;
using ColombianCoffeeApp.src.Modules.Usuarios.Application.Interfaces;

namespace Borrador2.src.UI
{
    public class MenuPrincipal : IMenu
    {
        private readonly IUsuarioService _usuarioService;

        public MenuPrincipal(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task MostrarAsync()
        {
            bool salir = false;

            while (!salir)
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

                switch (opcion)
                {
                    case "1":
                        await IniciarSesionAsync();
                        break;
                    case "2":
                        await CrearCuentaAsync();
                        break;
                    case "3":
                        salir = true;
                        Console.WriteLine("👋 ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("❌ Opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private async Task IniciarSesionAsync()
        {
            Console.WriteLine("🔐 Iniciar Sesión");
            Console.Write("\nUsuario: ");
            string usuario = Console.ReadLine() ?? "";
            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine() ?? "";

            var result = await _usuarioService.LoginAsync(usuario, contrasena);

            if (result == null)
            {
                Console.WriteLine("❌ Usuario o contraseña incorrectos.");
                Console.ReadKey();
                return;
            }

            IMenu menuRol = result.Rol == RolUsuario.Administrador
                ? new MenuAdmin()
                : new MenuUsuario();

            await menuRol.MostrarAsync();
        }

        private async Task CrearCuentaAsync()
        {
            Console.Write("Nuevo usuario: ");
            string usuario = Console.ReadLine() ?? "";
            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine() ?? "";
            Console.Write("Rol (Administrador/Usuario): ");
            string rol = Console.ReadLine() ?? "";

            await _usuarioService.CrearUsuarioAsync(usuario, contrasena, rol);
            Console.WriteLine("✅ Usuario creado. Inicie sesión para continuar.");
            Console.ReadKey();
        }
    }

}