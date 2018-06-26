using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Siniestro
    {
        public int IdSiniestro { get; set; }
        public DateTime? Fecha { get; set; }
        public string CallePrincipal { get; set; }
        public string CalleSecundaria { get; set; }
        public string Referencia { get; set; }
    }
}
