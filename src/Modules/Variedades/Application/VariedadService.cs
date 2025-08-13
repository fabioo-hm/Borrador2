using System;
using System.Collections.Generic;
using ColombianCoffeeApp.src.Modules.Variedades.Domain.Entities;
using ColombianCoffeeApp.src.Modules.Variedades.Infrastructure.Repositories;

namespace ColombianCoffeeApp.src.Modules.Variedades.Application
{
    public class VariedadService
    {
        private readonly RepositorioVariedades _repositorio;

        public VariedadService(RepositorioVariedades repositorio)
        {
            _repositorio = repositorio;
        }

        public void CrearVariedad(VariedadCafe variedad)
        {
            if (string.IsNullOrWhiteSpace(variedad.NombreComun))
                throw new ArgumentException("El nombre común es obligatorio");

            if (string.IsNullOrWhiteSpace(variedad.NombreCientifico))
                throw new ArgumentException("El nombre científico es obligatorio");

            _repositorio.Agregar(variedad);
        }

        public List<VariedadCafe> ObtenerTodas()
        {
            return _repositorio.ObtenerTodas();
        }

        public VariedadCafe ObtenerPorId(int id)
        {
            var variedad = _repositorio.ObtenerPorId(id);
            if (variedad == null)
                throw new KeyNotFoundException($"No se encontró una variedad con el ID {id}");
            return variedad;
        }


        public void ActualizarVariedad(VariedadCafe variedad)
        {
            if (variedad.Id <= 0)
                throw new ArgumentException("ID inválido para actualizar");

            _repositorio.Actualizar(variedad);
        }

        public void EliminarVariedad(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido para eliminar");

            _repositorio.Eliminar(id);
        }

        public List<VariedadCafe> FiltrarPorAtributo(string atributo, string valor)
        {
            if (string.IsNullOrWhiteSpace(atributo) || string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("El atributo y el valor no pueden estar vacíos");

            switch (atributo.Trim().ToLower())
            {
                case "porte":
                    return _repositorio.FiltrarVariedades(porte: valor);
                case "tamanograno":
                    return _repositorio.FiltrarVariedades(tamanoGrano: valor);
                case "rendimiento":
                    return _repositorio.FiltrarVariedades(rendimiento: valor);
                case "calidadgrano":
                    return _repositorio.FiltrarVariedades(calidad: valor);
                case "resistenciaroya":
                    return _repositorio.FiltrarVariedades(resistenciaTipo: "roya", resistenciaValor: valor);
                case "resistenciaantracnosis":
                    return _repositorio.FiltrarVariedades(resistenciaTipo: "antracnosis", resistenciaValor: valor);
                case "resistencianematodos":
                    return _repositorio.FiltrarVariedades(resistenciaTipo: "nematodos", resistenciaValor: valor);
                default:
                    return new List<VariedadCafe>();
            }
        }

        public IEnumerable<VariedadCafe> FiltrarPorAtributos(List<(string atributo, string valor)> filtros)
        {
            var lista = _repositorio.ObtenerTodas();

            foreach (var (atributo, valor) in filtros)
            {
                var prop = typeof(VariedadCafe).GetProperty(atributo);
                if (prop == null)
                    throw new ArgumentException($"El atributo '{atributo}' no existe.");

                lista = lista
                    .Where(v => 
                        {
                            var propValue = prop.GetValue(v);
                            return propValue?.ToString()?.Equals(valor, StringComparison.OrdinalIgnoreCase) == true;
                        }
                    )
                    .ToList();
            }

            return lista;
        }



        public List<VariedadCafe> Sugerencias(string porte, string resistenciaRoya)
        {
            return _repositorio.FiltrarVariedades(
                porte: porte,
                resistenciaTipo: "roya",
                resistenciaValor: resistenciaRoya
            );
        }
    }
}
