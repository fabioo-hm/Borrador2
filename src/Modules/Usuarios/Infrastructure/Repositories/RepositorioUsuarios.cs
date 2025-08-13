using System.Collections.Generic;
using System.Linq;
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

        // LOGIN
        public Usuario? ObtenerPorCredenciales(string nombreUsuario, string contrasena)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena);
        }

        // CREAR USUARIO
        public void Crear(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        // OBTENER POR NOMBRE
        public Usuario? ObtenerPorNombre(string nombreUsuario)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
        }

        // LISTAR TODOS
        public List<Usuario> ListarTodos()
        {
            return _context.Usuarios.ToList();
        }

        // ELIMINAR POR ID
        public bool Eliminar(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
