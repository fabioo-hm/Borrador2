using System;
using System.Collections.Generic;
using ColombianCoffeeApp.src.Modules.Variedades.Domain.Entities;

namespace ColombianCoffeeApp.src.Modules.Variedades.Application.Interfaces
{
    public interface IVariedadService
    {
        void CrearVariedad(VariedadCafe variedad);
        List<VariedadCafe> ObtenerTodas();
        VariedadCafe ObtenerPorId(int id);
        void ActualizarVariedad(VariedadCafe variedad);
        void EliminarVariedad(int id);
        List<VariedadCafe> FiltrarPorAtributo(string atributo, string valor);
        IEnumerable<VariedadCafe> FiltrarPorAtributos(List<(string atributo, string valor)> filtros);
        List<VariedadCafe> Sugerencias(string porte, string resistenciaRoya);
    }
}
