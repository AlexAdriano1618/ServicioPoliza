using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Seguro = new HashSet<Seguro>();
        }

        public int IdVehiculo { get; set; }
        public int IdMarca { get; set; }
        public int IdModelo { get; set; }
        public string Placa { get; set; }
        public string Chasis { get; set; }
        public string Color { get; set; }
        public string Observaciones { get; set; }
        public int? TipVehiculoo { get; set; }
        public string Estado { get; set; }
        public string AnioDeFabricacion { get; set; }

        public Marca IdMarcaNavigation { get; set; }
        public Modelo IdVehiculoNavigation { get; set; }
        public ICollection<Seguro> Seguro { get; set; }
    }
}
