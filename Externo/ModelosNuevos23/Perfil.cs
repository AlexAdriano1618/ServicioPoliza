using System;
using System.Collections.Generic;

namespace Externo.ModelosNuevos23
{
    public partial class Perfil
    {
        public Perfil()
        {
            ItemMenu = new HashSet<ItemMenu>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdPerfil { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public ICollection<ItemMenu> ItemMenu { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
