using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColombianCoffeeApp.src.Modules.Variedades.Domain.Entities
{
    public class VariedadCafe
    {
        public int Id { get; set; }
        public string? NombreComun { get; set; }
        public string? Descripcion { get; set; }
        public string? NombreCientifico { get; set; }
        public string? RutaImagen { get; set; }
        public string? Porte { get; set; }
        public string? TamanoGrano { get; set; } 
        public int AltitudOptima { get; set; }
        public string? Rendimiento { get; set; }
        public string? CalidadGrano { get; set; } 
        public string? ResistenciaRoya { get; set; } 
        public string? ResistenciaAntracnosis { get; set; }
        public string? ResistenciaNematodos { get; set; }
        public string? TiempoCosecha { get; set; }
        public string? TiempoMaduracion { get; set; }
        public string? RecomendacionNutricion { get; set; }
        public string? DensidadSiembra { get; set; }
        public string? Historia { get; set; }
        public string? GrupoGenetico { get; set; }
        public string? Obtentor { get; set; }
        public string? Familia { get; set; }
    }
}