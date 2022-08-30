using System;
using System.Collections.Generic;

namespace FeriaUDEO2022API.Models
{
    public partial class VotoUsuario
    {
        public int IdVotoUsuario { get; set; }
        public int? IdProyecto { get; set; }
        public int? IdUsuario { get; set; }
        public decimal Puntuacion { get; set; }

        public virtual Proyecto? IdProyectoNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
