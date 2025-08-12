using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BorradoColombianCoffee.src.Modules.Usuarios.Domain;
using ColombianCoffeeApp.src.Modules.Usuarios.Application;
using ColombianCoffeeApp.src.Modules.Variedades.Application;
using ColombianCoffeeApp.src.Modules.Variedades.Infrastructure.Repositories;
using ColombianCoffeeApp.src.Modules.Variedades.UI;
using Microsoft.EntityFrameworkCore.Internal;
using Shared.Helpers;

namespace ColombianCoffeeApp.src.Modules.Usuarios.UI
{
    public class MenuAdmin
    {
        private readonly UsuarioService _usuarioService;

        public MenuAdmin(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public void Mostrar()
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN ADMINISTRADOR ===");
            Console.Write("Usuario: ");
            string? username = Console.ReadLine();
            Console.Write("Contraseña: ");
            string? password = Console.ReadLine();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("❌ Usuario y/o contraseña no pueden estar vacíos.");
                Console.ReadKey();
                return;
            }

            var usuario = _usuarioService.Login(username, password);
            if (usuario == null)
            {
                Console.WriteLine("❌ Credenciales inválidas o no tiene permisos de administrador.");
                Console.ReadKey();
                return;
            }
            if (usuario.Rol != RolUsuario.Administrador)
            {
                Console.WriteLine("❌ Credenciales inválidas o no tiene permisos de administrador.");
                Console.ReadKey();
                return;
            }


            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== PANEL ADMINISTRADOR ===");
                Console.WriteLine("1. Administrar variedades");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AdministrarVariedades();
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

        private void AdministrarVariedades()
        {
            using (var db = DbContextFactory.Create())
            {
                var repoVariedades = new RepositorioVariedades(db);
                var serviceVariedades = new VariedadService(repoVariedades);
                var menuAdminVariedades = new MenuAdminVariedad(serviceVariedades);
                menuAdminVariedades.Mostrar();
            }
        }
    }
}