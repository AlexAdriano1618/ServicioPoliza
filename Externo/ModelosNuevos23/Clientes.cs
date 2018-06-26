using System;
using System.Collections.Generic;

namespace Externo.ModelosNuevos23
{
    public partial class Clientes
    {
        public Clientes()
        {
            Poliza = new HashSet<Poliza>();
        }

        public int IdCliente { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }

        public ICollection<Poliza> Poliza { get; set; }
    }
}
