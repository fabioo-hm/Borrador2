using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ColombianCoffeeApp.src.Shared.Context;
using ColombianCoffeeApp.src.Modules.Variedades.Domain.Entities;
using ColombianCoffeeApp.src.Modules.Variedades.Application.Interfaces;

namespace ColombianCoffeeApp.src.Modules.Variedades.Infrastructure.Repositories
{
    public class RepositorioVariedades : IVariedadRepository
    {
        private readonly AppDbContext _context;

        public RepositorioVariedades(AppDbContext context)
        {
            _context = context;
        }

        public void Agregar(VariedadCafe variedad)
        {
            _context.Variedades.Add(variedad);
            _context.SaveChanges();
        }

        public List<VariedadCafe> ObtenerTodas()
        {
            return _context.Variedades.ToList();
        }

        public VariedadCafe? ObtenerPorId(int id)
        {
            return _context.Variedades.FirstOrDefault(v => v.Id == id);
        }

        public void Actualizar(VariedadCafe variedad)
        {
            _context.Variedades.Update(variedad);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var variedad = ObtenerPorId(id);
            if (variedad != null)
            {
                _context.Variedades.Remove(variedad);
                _context.SaveChanges();
            }
        }

        public List<VariedadCafe> FiltrarVariedades(
            string? porte = null,
            string? tamanoGrano = null,
            int? altitudMin = null,
            int? altitudMax = null,
            string? rendimiento = null,
            string? calidad = null,
            string? resistenciaTipo = null,
            string? resistenciaValor = null)
        {
            var query = _context.Variedades.AsQueryable();

            if (!string.IsNullOrWhiteSpace(porte))
                query = query.Where(v => v.Porte.ToString().ToLower() == porte.ToLower());

            if (!string.IsNullOrWhiteSpace(tamanoGrano))
                query = query.Where(v => v.TamanoGrano.ToString().ToLower() == tamanoGrano.ToLower());

            if (altitudMin.HasValue)
                query = query.Where(v => v.AltitudOptima >= altitudMin.Value);

            if (altitudMax.HasValue)
                query = query.Where(v => v.AltitudOptima <= altitudMax.Value);

            if (!string.IsNullOrWhiteSpace(rendimiento))
                query = query.Where(v => v.Rendimiento.ToString().ToLower() == rendimiento.ToLower());

            if (!string.IsNullOrWhiteSpace(calidad))
                query = query.Where(v => v.CalidadGrano.ToString().ToLower() == calidad.ToLower());

            if (!string.IsNullOrWhiteSpace(resistenciaValor))
            {
                var val = resistenciaValor.ToLower();

                if (string.IsNullOrWhiteSpace(resistenciaTipo))
                {
                    query = query.Where(v =>
                        v.ResistenciaRoya.ToString().ToLower() == val ||
                        v.ResistenciaAntracnosis.ToString().ToLower() == val ||
                        v.ResistenciaNematodos.ToString().ToLower() == val
                    );
                }
                else
                {
                    switch (resistenciaTipo.Trim().ToLower())
                    {
                        case "roya":
                            query = query.Where(v => v.ResistenciaRoya.ToString().ToLower() == val);
                            break;
                        case "antracnosis":
                            query = query.Where(v => v.ResistenciaAntracnosis.ToString().ToLower() == val);
                            break;
                        case "nematodos":
                            query = query.Where(v => v.ResistenciaNematodos.ToString().ToLower() == val);
                            break;
                        default:
                            query = query.Where(v =>
                                v.ResistenciaRoya.ToString().ToLower() == val ||
                                v.ResistenciaAntracnosis.ToString().ToLower() == val ||
                                v.ResistenciaNematodos.ToString().ToLower() == val
                            );
                            break;
                    }
                }
            }

            return query.ToList();
        }
    }
}