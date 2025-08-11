using System;
using System.Linq;
using ColombianCoffeeApp.src.Shared.Context;
using ColombianCoffeeApp.src.Modules.Variedades.Domain.Entities;

namespace ColombianCoffeeApp
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Variedades.Any())
            {
                var variedades = new[]
                {
                    new VariedadCafe
                    {
                        NombreComun = "Castillo",
                        NombreCientifico = "Coffea arabica var. Castillo",
                        Descripcion = "Alta resistencia a la roya, porte medio y buena calidad de taza.",
                        Porte = "Medio",
                        TamanoGrano = "Grande",
                        AltitudOptima = 1800,
                        Rendimiento = "Alto",
                        CalidadGrano = "Alta",
                        ResistenciaRoya = "Alta",
                        ResistenciaAntracnosis = "Media",
                        ResistenciaNematodos = "Baja",
                        TiempoCosecha = "8 meses",
                        TiempoMaduracion = "6 meses",
                        RecomendacionNutricion = "Fertilización cada 4 meses",
                        DensidadSiembra = "5000 plantas/ha",
                        Historia = "Desarrollada por Cenicafé en Colombia",
                        GrupoGenetico = "Híbrido",
                        Obtentor = "Cenicafé",
                        Familia = "Rubiaceae"
                    },
                    new VariedadCafe
                    {
                        NombreComun = "Caturra",
                        NombreCientifico = "Coffea arabica var. Caturra",
                        Descripcion = "Variedad compacta con alta densidad de siembra.",
                        Porte = "Bajo",
                        TamanoGrano = "Mediano",
                        AltitudOptima = 1500,
                        Rendimiento = "Medio",
                        CalidadGrano = "Alta",
                        ResistenciaRoya = "Baja",
                        ResistenciaAntracnosis = "Media",
                        ResistenciaNematodos = "Alta",
                        TiempoCosecha = "9 meses",
                        TiempoMaduracion = "7 meses",
                        RecomendacionNutricion = "Fertilización cada 6 meses",
                        DensidadSiembra = "6000 plantas/ha",
                        Historia = "Originaria de Brasil",
                        GrupoGenetico = "Típica",
                        Obtentor = "Productores brasileños",
                        Familia = "Rubiaceae"
                    }
                };

                context.Variedades.AddRange(variedades);
                context.SaveChanges();
                Console.WriteLine("✅ Datos iniciales insertados en la base de datos.");
            }
            else
            {
                Console.WriteLine("ℹ️ Datos ya existentes en la base de datos.");
            }
        }
    }
}
