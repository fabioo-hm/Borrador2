using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BorradoColombianCoffee.src.Modules.Usuarios.Domain;

namespace ColombianCoffeeApp.src.Modules.Usuarios.Domain.Entities;
//[Table("usuario")]
    public class Usuario
{
    public int Id { get; set; }
    public string? NombreUsuario { get; set; }
    public string? Contrasena { get; set; }
    public RolUsuario Rol { get; set; }
}
