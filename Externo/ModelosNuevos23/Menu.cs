using System;
using System.Collections.Generic;

namespace Externo.ModelosNuevos23
{
    public partial class Menu
    {
        public Menu()
        {
            ItemMenu = new HashSet<ItemMenu>();
        }

        public int IdMenu { get; set; }
        public string Titulo { get; set; }
        public string Url { get; set; }
        public string Estado { get; set; }
        public string TipoMenu { get; set; }

        public ICollection<ItemMenu> ItemMenu { get; set; }
    }
}
