using System.Collections.Generic;
using ColombianCoffeeApp.src.Modules.Variedades.Domain.Entities;

namespace ColombianCoffeeApp.src.Modules.Variedades.Application.Interfaces
{
    public interface IVariedadRepository
    {
        void Agregar(VariedadCafe variedad);
        List<VariedadCafe> ObtenerTodas();
        VariedadCafe? ObtenerPorId(int id);
        void Actualizar(VariedadCafe variedad);
        void Eliminar(int id);
        List<VariedadCafe> FiltrarVariedades(
            string? porte = null,
            string? tamanoGrano = null,
            int? altitudMin = null,
            int? altitudMax = null,
            string? rendimiento = null,
            string? calidad = null,
            string? resistenciaTipo = null,
            string? resistenciaValor = null
        );
    }
}
