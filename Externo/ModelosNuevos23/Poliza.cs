using System;
using System.Collections.Generic;

namespace Externo.ModelosNuevos23
{
    public partial class Poliza
    {
        public Poliza()
        {
            Seguro = new HashSet<Seguro>();
        }

        public int IdPoliza { get; set; }
        public DateTime? FechaCoverturaI { get; set; }
        public DateTime? FechaCoverturaF { get; set; }
        public string NumPoliza { get; set; }
        public string Factura { get; set; }
        public decimal? TotValAsegurado { get; set; }
        public decimal? TotValPrima { get; set; }
        public int IdCliente { get; set; }

        public Clientes IdClienteNavigation { get; set; }
        public ICollection<Seguro> Seguro { get; set; }
    }
}
