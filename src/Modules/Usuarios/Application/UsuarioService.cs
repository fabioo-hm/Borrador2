using System;
using System.Collections.Generic;
using BorradoColombianCoffee.src.Modules.Usuarios.Domain;
using ColombianCoffeeApp.src.Modules.Usuarios.Domain.Entities;
using ColombianCoffeeApp.src.Modules.Usuarios.Infrastructure.Repositories;

namespace ColombianCoffeeApp.src.Modules.Usuarios.Application
{
    public class UsuarioService
    {
        private readonly RepositorioUsuarios _repo;

        public UsuarioService(RepositorioUsuarios repo)
        {
            _repo = repo;
        }

        // LOGIN
        public Usuario? Login(string nombreUsuario, string contrasena)
        {
            return _repo.ObtenerPorCredenciales(nombreUsuario, contrasena);
        }

        // REGISTRAR ADMIN
        public void RegistrarAdmin(string nombreUsuario, string contrasena)
        {
            if (_repo.ObtenerPorNombre(nombreUsuario) != null)
            {
                Console.WriteLine("⚠️ Ya existe un usuario con ese nombre.");
                return;
            }

            var admin = new Usuario
            {
                NombreUsuario = nombreUsuario,
                Contrasena = contrasena,
                Rol = RolUsuario.Administrador
            };
            _repo.Crear(admin);
        }

        // CREAR USUARIO GENÉRICO
        public void CrearUsuario(string nombreUsuario, string contrasena, string rolTexto)
        {
            if (_repo.ObtenerPorNombre(nombreUsuario) != null)
            {
                Console.WriteLine("⚠️ Ya existe un usuario con ese nombre.");
                return;
            }

            RolUsuario rol;
            if (!Enum.TryParse(rolTexto, true, out rol))
            {
                Console.WriteLine("⚠️ Rol inválido. Se asignará 'Usuario' por defecto.");
                rol = RolUsuario.Usuario;
            }

            var usuario = new Usuario
            {
                NombreUsuario = nombreUsuario,
                Contrasena = contrasena,
                Rol = rol
            };

            _repo.Crear(usuario);
            Console.WriteLine("✅ Usuario creado correctamente.");
        }

        // LISTAR USUARIOS
        public List<Usuario> ObtenerTodos()
        {
            return _repo.ListarTodos();
        }

        // ELIMINAR USUARIO POR ID
        public bool Eliminar(int id)
        {
            return _repo.Eliminar(id);
        }

        // OBTENER POR NOMBRE
        public Usuario? ObtenerPorNombre(string nombreUsuario)
        {
            return _repo.ObtenerPorNombre(nombreUsuario);
        }
    }
}
