using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Persona
    {
        public int IdPersona { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public bool? Estado { get; set; }
        public int IdGenero { get; set; }

        public Genero IdGeneroNavigation { get; set; }
    }
}
