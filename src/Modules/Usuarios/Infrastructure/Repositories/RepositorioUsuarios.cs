using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Usuarios.Domain.Entities;
using ColombianCoffeeApp.src.Shared.Context;
using Microsoft.EntityFrameworkCore;
using ColombianCoffeeApp.src.Modules.Usuarios.Infrastructure.Repositories.Interfaces;

namespace ColombianCoffeeApp.src.Modules.Usuarios.Infrastructure.Repositories
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly AppDbContext _context;

        public RepositorioUsuarios(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObtenerPorCredencialesAsync(string nombreUsuario, string contrasena)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena);
        }

        public async Task CrearAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario?> ObtenerPorNombreAsync(string nombreUsuario)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
        }

        public async Task<List<Usuario>> ListarTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
