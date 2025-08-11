using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Usuarios.Domain.Entities;
using ColombianCoffeeApp.src.Shared.Context;

namespace ColombianCoffeeApp.src.Modules.Usuarios.Infrastructure.Repositories
{
    public class RepositorioUsuarios
    {
        private readonly AppDbContext _context;

        public RepositorioUsuarios(AppDbContext context)
        {
            _context = context;
        }

        public Usuario? ObtenerPorCredenciales(string nombreUsuario, string contrasena)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena);
        }

        public void Crear(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
    }
}