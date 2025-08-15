using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.Services;
using ColombianCoffeeApp.src.Modules.Usuarios.UI;
using ColombianCoffeeApp.src.Modules.Variedades.UI;
using Microsoft.EntityFrameworkCore.Internal;
using Shared.Helpers;

namespace Borrador2.src.UI
{
    public class MenuAdmin : IMenu
    {
        public async Task MostrarAsync()
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
                        await new MenuUsuarios().Mostrar();
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

}