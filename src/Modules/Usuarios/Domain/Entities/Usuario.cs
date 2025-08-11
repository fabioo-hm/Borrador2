using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColombianCoffeeApp.src.Modules.Usuarios.Domain.Entities
{
    public class Usuario
    {
         public int Id { get; set; }
        public string ?NombreUsuario { get; set; }
        public string ?Contrasena { get; set; }
        public string ?Rol { get; set; }
    }
}