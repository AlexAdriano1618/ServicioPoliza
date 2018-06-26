using System;
using System.Collections.Generic;

namespace Externo.ModelosNuevos23
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Login = new HashSet<Login>();
        }

        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }
        public int IdPerfil { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }

        public Perfil IdPerfilNavigation { get; set; }
        public ICollection<Login> Login { get; set; }
    }
}
