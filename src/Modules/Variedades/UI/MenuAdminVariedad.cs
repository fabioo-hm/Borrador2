using System;
using System.Linq;
using ColombianCoffeeApp.src.Modules.Variedades.Domain.Entities;
using ColombianCoffeeApp.src.Modules.Variedades.Application;
using Borrador2.src.Modules.Variedades.Domain;

namespace ColombianCoffeeApp.src.Modules.Variedades.UI
{
    public class MenuAdminVariedad
    {
        private readonly VariedadService _service;

        public MenuAdminVariedad(VariedadService service)
        {
            _service = service;
        }

        public void Mostrar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ADMINISTRACIÓN DE VARIEDADES ===");
                Console.WriteLine("1. Crear nueva variedad");
                Console.WriteLine("2. Editar variedad");
                Console.WriteLine("3. Eliminar variedad");
                Console.WriteLine("4. Listar variedades");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearVariedad();
                        break;
                    case "2":
                        EditarVariedad();
                        break;
                    case "3":
                        EliminarVariedad();
                        break;
                    case "4":
                        ListarVariedades();
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

        private void CrearVariedad()
        {
            Console.Clear();
            Console.WriteLine("=== CREAR NUEVA VARIEDAD ===");
            var variedad = new VariedadCafe();

            Console.Write("Nombre común: ");
            variedad.NombreComun = Console.ReadLine();

            Console.Write("Nombre científico: ");
            variedad.NombreCientifico = Console.ReadLine();

            Console.Write("Descripción: ");
            variedad.Descripcion = Console.ReadLine();

            Console.Write("Ruta imagen: ");
            variedad.RutaImagen = Console.ReadLine();

            // ---- Enums ----
            variedad.Porte = LeerEnum<PorteVariedad>("Porte (Alto/Medio/Bajo)");
            variedad.TamanoGrano = LeerEnum<TamanoGranoVariedad>("Tamaño grano (Pequeño/Medio/Grande)");

            Console.Write("Altitud óptima (número): ");
            if (!int.TryParse(Console.ReadLine(), out int altitudOptima))
            {
                Console.WriteLine("Valor inválido para altitud óptima. Presione una tecla...");
                Console.ReadKey();
                return;
            }
            variedad.AltitudOptima = altitudOptima;

            variedad.Rendimiento = LeerEnum<RendimientoVariedad>("Rendimiento (Bajo/Medio/Alto)");

            Console.Write("Calidad del grano (número): ");
            if (!int.TryParse(Console.ReadLine(), out int calidadGrano))
            {
                Console.WriteLine("Valor inválido para calidad del grano. Presione una tecla...");
                Console.ReadKey();
                return;
            }
            variedad.CalidadGrano = calidadGrano;

            variedad.ResistenciaRoya = LeerEnum<RoyaVariedad>("Resistencia Roya (Baja/Media/Alta)");
            variedad.ResistenciaAntracnosis = LeerEnum<AntracnosisVariedad>("Resistencia Antracnosis (Baja/Media/Alta)");
            variedad.ResistenciaNematodos = LeerEnum<NematodosVariedad>("Resistencia Nematodos (Baja/Media/Alta)");

            Console.Write("Tiempo de cosecha: ");
            variedad.TiempoCosecha = Console.ReadLine();

            Console.Write("Tiempo de maduración: ");
            variedad.TiempoMaduracion = Console.ReadLine();

            Console.Write("Recomendación nutricional: ");
            variedad.RecomendacionNutricion = Console.ReadLine();

            Console.Write("Densidad de siembra: ");
            variedad.DensidadSiembra = Console.ReadLine();

            Console.Write("Historia: ");
            variedad.Historia = Console.ReadLine();

            Console.Write("Grupo genético: ");
            variedad.GrupoGenetico = Console.ReadLine();

            Console.Write("Obtentor: ");
            variedad.Obtentor = Console.ReadLine();

            Console.Write("Familia: ");
            variedad.Familia = Console.ReadLine();

            _service.CrearVariedad(variedad);
            Console.WriteLine("✅ Variedad creada con éxito. Presione una tecla...");
            Console.ReadKey();
        }

        private void EditarVariedad()
        {
            Console.Clear();
            Console.WriteLine("=== EDITAR VARIEDAD ===");
            Console.Write("Ingrese el ID de la variedad a editar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                Console.ReadKey();
                return;
            }

            var variedad = _service.ObtenerPorId(id);
            if (variedad == null)
            {
                Console.WriteLine("No se encontró la variedad.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Editando: {variedad.NombreComun}");
            Console.Write("Nuevo nombre común (enter para no cambiar): ");
            var nuevoValor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoValor)) variedad.NombreComun = nuevoValor;

            Console.Write("Nuevo nombre científico: ");
            nuevoValor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoValor)) variedad.NombreCientifico = nuevoValor;

            Console.Write("Nueva descripción: ");
            nuevoValor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoValor)) variedad.Descripcion = nuevoValor;

            _service.ActualizarVariedad(variedad);
            Console.WriteLine("✅ Variedad actualizada con éxito.");
            Console.ReadKey();
        }

        private void EliminarVariedad()
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR VARIEDAD ===");
            Console.Write("Ingrese el ID de la variedad a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                Console.ReadKey();
                return;
            }

            _service.EliminarVariedad(id);
            Console.WriteLine("✅ Variedad eliminada con éxito.");
            Console.ReadKey();
        }

        private void ListarVariedades()
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

        // Método genérico para leer y validar enums
        private T LeerEnum<T>(string mensaje) where T : struct
        {
            while (true)
            {
                Console.Write($"{mensaje}: ");
                var input = Console.ReadLine();
                if (Enum.TryParse<T>(input, true, out var valor))
                    return valor;

                Console.WriteLine("❌ Valor inválido. Intente de nuevo.");
            }
        }
    }
}
