using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Login
    {
        public int IdLogin { get; set; }
        public DateTime? FechaCambio { get; set; }
        public string Clave { get; set; }
        public string Usuario { get; set; }
        public string Estado { get; set; }
        public int? IdUsuario { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
