using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class ItemMenu
    {
        public int IdSubMenu { get; set; }
        public int? IdPerfil { get; set; }
        public int? IdMenu { get; set; }
        public string Estado { get; set; }

        public Menu IdMenuNavigation { get; set; }
        public Perfil IdPerfilNavigation { get; set; }
    }
}
