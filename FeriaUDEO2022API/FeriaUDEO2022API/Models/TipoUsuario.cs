using System;
using System.Collections.Generic;

namespace FeriaUDEO2022API.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
