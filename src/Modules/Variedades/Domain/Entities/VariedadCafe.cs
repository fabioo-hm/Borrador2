using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Borrador2.src.Modules.Variedades.Domain;

namespace ColombianCoffeeApp.src.Modules.Variedades.Domain.Entities;
    [Table("variedad")]
    public class VariedadCafe
    {
        public int Id { get; set; }
        public string? NombreComun { get; set; }
        public string? Descripcion { get; set; }
        public string? NombreCientifico { get; set; }
        public string? RutaImagen { get; set; }
        public PorteVariedad Porte { get; set; }
        public TamanoGranoVariedad TamanoGrano { get; set; } 
        public int AltitudOptima { get; set; }
        public RendimientoVariedad Rendimiento { get; set; }
        public int CalidadGrano { get; set; } 
        public RoyaVariedad ResistenciaRoya { get; set; } 
        public AntracnosisVariedad ResistenciaAntracnosis { get; set; }
        public NematodosVariedad ResistenciaNematodos { get; set; }
        public string? TiempoCosecha { get; set; }
        public string? TiempoMaduracion { get; set; }
        public string? RecomendacionNutricion { get; set; }
        public string? DensidadSiembra { get; set; }
        public string? Historia { get; set; }
        public string? GrupoGenetico { get; set; }
        public string? Obtentor { get; set; }
        public string? Familia { get; set; }
    }
