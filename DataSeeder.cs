using System;
using System.Linq;
using ColombianCoffeeApp.src.Shared.Context;
using ColombianCoffeeApp.src.Modules.Variedades.Domain.Entities;
using Borrador2.src.Modules.Variedades.Domain; // para que reconozca los enums

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
                        Porte = PorteVariedad.Alto,
                        TamanoGrano = TamanoGranoVariedad.Grande,
                        AltitudOptima = 1800,
                        Rendimiento = RendimientoVariedad.Alto,
                        CalidadGrano = 5, // o el valor que uses para representar "Alta"
                        ResistenciaRoya = RoyaVariedad.Suseptible,
                        ResistenciaAntracnosis = AntracnosisVariedad.Tolerante,
                        ResistenciaNematodos = NematodosVariedad.Resistente,
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
                        Porte = PorteVariedad.Bajo,
                        TamanoGrano = TamanoGranoVariedad.Mediano,
                        AltitudOptima = 1500,
                        Rendimiento = RendimientoVariedad.Medio,
                        CalidadGrano = 5, // "Alta"
                        ResistenciaRoya = RoyaVariedad.Tolerante,
                        ResistenciaAntracnosis = AntracnosisVariedad.Resistente,
                        ResistenciaNematodos = NematodosVariedad.Resistente,
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
