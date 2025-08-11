using System;
using System.Collections.Generic;
using System.Linq;
using ColombianCoffeeApp.src.Modules.Variedades.Domain.Entities;
using ColombianCoffeeApp.src.Modules.Variedades.Application;

namespace ColombianCoffeeApp.src.Modules.Variedades.UI
{
    public class MenuExploracion
    {
        private readonly VariedadService _service;

        public MenuExploracion(VariedadService service)
        {
            _service = service;
        }

        public void Mostrar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== EXPLORAR VARIEDADES DE CAFÉ ===");
                Console.WriteLine("1. Listar todas");
                Console.WriteLine("2. Ver ficha técnica por ID");
                Console.WriteLine("3. Filtrar por atributo");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarTodas();
                        break;
                    case "2":
                        VerFichaPorId();
                        break;
                    case "3":
                        FiltrarPorAtributo();
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

        private void ListarTodas()
        {
            Console.Clear();
            var variedades = _service.ObtenerTodas();

            if (!variedades.Any())
            {
                Console.WriteLine("No hay variedades registradas.");
            }
            else
            {
                foreach (var v in variedades)
                {
                    Console.WriteLine($"{v.Id} - {v.NombreComun} ({v.NombreCientifico})");
                }
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void VerFichaPorId()
        {
            Console.Write("\nIngrese el ID de la variedad: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var variedad = _service.ObtenerPorId(id);
                if (variedad != null)
                {
                    MostrarFichaTecnica(variedad);
                }
                else
                {
                    Console.WriteLine("No se encontró la variedad.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void FiltrarPorAtributo()
        {
            Console.Write("\nIngrese el nombre del atributo (ej: Porte, TamanoGrano): ");
            string? atributo = Console.ReadLine();
            Console.Write("Ingrese el valor a buscar: ");
            string? valor = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(atributo) || string.IsNullOrWhiteSpace(valor))
            {
                Console.WriteLine("El atributo y el valor no pueden estar vacíos.");
            }
            else
            {
                try
                {
                    var resultados = _service.FiltrarPorAtributo(atributo, valor);

                    if (!resultados.Any())
                    {
                        Console.WriteLine("No se encontraron variedades con ese criterio.");
                    }
                    else
                    {
                        foreach (var v in resultados)
                        {
                            Console.WriteLine($"{v.Id} - {v.NombreComun} ({v.NombreCientifico})");
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void MostrarFichaTecnica(VariedadCafe v)
        {
            Console.Clear();
            Console.WriteLine($"=== Ficha Técnica de {v.NombreComun} ===");
            Console.WriteLine($"Nombre Científico: {v.NombreCientifico}");
            Console.WriteLine($"Descripción: {v.Descripcion}");
            Console.WriteLine($"Porte: {v.Porte}");
            Console.WriteLine($"Tamaño del Grano: {v.TamanoGrano}");
            Console.WriteLine($"Altitud Óptima: {v.AltitudOptima} msnm");
            Console.WriteLine($"Rendimiento: {v.Rendimiento}");
            Console.WriteLine($"Calidad del Grano: {v.CalidadGrano}");
            Console.WriteLine($"Resistencia a Roya: {v.ResistenciaRoya}");
            Console.WriteLine($"Resistencia a Antracnosis: {v.ResistenciaAntracnosis}");
            Console.WriteLine($"Resistencia a Nematodos: {v.ResistenciaNematodos}");
            Console.WriteLine($"Tiempo de Cosecha: {v.TiempoCosecha}");
            Console.WriteLine($"Tiempo de Maduración: {v.TiempoMaduracion}");
            Console.WriteLine($"Recomendación Nutricional: {v.RecomendacionNutricion}");
            Console.WriteLine($"Densidad de Siembra: {v.DensidadSiembra}");
            Console.WriteLine($"Historia: {v.Historia}");
            Console.WriteLine($"Grupo Genético: {v.GrupoGenetico}");
            Console.WriteLine($"Obtentor: {v.Obtentor}");
            Console.WriteLine($"Familia: {v.Familia}");
        }
    }
}
