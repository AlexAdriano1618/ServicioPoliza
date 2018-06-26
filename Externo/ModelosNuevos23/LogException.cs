using System;
using System.Collections.Generic;

namespace Externo.ModelosNuevos23
{
    public partial class LogException
    {
        public int IdLog { get; set; }
        public DateTime? FechaLog { get; set; }
        public string Metodo { get; set; }
        public string Mensaje { get; set; }
        public string Trace { get; set; }
    }
}
