using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Modelo
    {
        public int IdModelo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public Vehiculo Vehiculo { get; set; }
    }
}
